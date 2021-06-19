using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    float freq;

    bool canPlayerFire = true;

    public ParticleSystem muzzleFlash;
    public GameObject impactObject;
    public GameObject bulletImpactObject;

    public AudioClip audioClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            //audioSource.loop = true;

            if (audioClip != null)
            {
                audioSource.clip = audioClip;
            }
        }

        freq = transform.parent.gameObject.GetComponent<AirPlane>().freqShoot;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canPlayerFire)
            {
                if (!muzzleFlash.isPlaying)
                    muzzleFlash.Play();

                if (audioSource != null)
                    audioSource.Play();

                StartCoroutine(Shoot());
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && audioSource != null)
        {
            StartCoroutine(AudioFadeOut.FadeOut(audioSource, 0.05f));
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            EnemyBehavior enemy = hit.transform.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        GameObject impactGO = Instantiate(impactObject, hit.point, Quaternion.LookRotation(hit.normal));
        GameObject bulletImpactGO = Instantiate(bulletImpactObject, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 1.5f);
        Destroy(bulletImpactGO, 4f);

        canPlayerFire = false;
        yield return new WaitForSeconds(freq);
        canPlayerFire = true;

    }
}


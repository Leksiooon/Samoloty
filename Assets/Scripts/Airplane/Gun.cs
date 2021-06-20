using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float damage;
    float range;
    float freq;
    float spreadFactor;

    bool canPlayerFire = true;

    public ParticleSystem muzzleFlash;
    public GameObject impactObject;
    public GameObject bulletImpactObject;

    public AudioClip audioClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioClip != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
            audioSource.clip = audioClip;
        }

        range = transform.parent.gameObject.GetComponent<AirPlane>().range;
        damage = transform.parent.gameObject.GetComponent<AirPlane>().damage;
        freq = transform.parent.gameObject.GetComponent<AirPlane>().freqShoot;
        spreadFactor = transform.parent.gameObject.GetComponent<AirPlane>().spreadFactor;
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
        Vector3 spreadForward = Vector3_MS.spreadVectorXY(transform.forward, spreadFactor);

        if (Physics.Raycast(transform.position, spreadForward, out hit, range))
        {
            if (!hit.collider.CompareTag("Area") && !hit.collider.CompareTag("Barrel"))
            {
                EnemyBehavior enemy = hit.transform.GetComponent<EnemyBehavior>();
                if (enemy != null)
                    enemy.TakeDamage(damage);

                GameObject impactGO = Instantiate(impactObject, hit.point, Quaternion.LookRotation(hit.normal));
                GameObject bulletImpactGO = Instantiate(bulletImpactObject, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1.5f);
                Destroy(bulletImpactGO, 4f);
            }
        }

        canPlayerFire = false;
        yield return new WaitForSeconds(freq);
        canPlayerFire = true;
    }
}


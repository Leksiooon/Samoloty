using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem muzzleFlash;
    public GameObject impactObject;

    public AudioClip audioClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = true;

            if (audioClip != null)
            {
                audioSource.clip = audioClip;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzleFlash.Play();
            if (audioSource != null)
                audioSource.Play();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Invoke("Shoot", 0.2f);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            muzzleFlash.Stop();
            if (audioSource != null)
                StartCoroutine(AudioFadeOut.FadeOut(audioSource, 0.05f));
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " " + transform.tag);

            EnemyBehavior enemy = hit.transform.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        GameObject impactGO = Instantiate(impactObject, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 1);
    }
}


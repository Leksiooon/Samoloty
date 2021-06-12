using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem muzzleFlash;

    public AudioClip audioClipStart;
    public AudioClip audioClipEnd;

    AudioSource audioSourceStart;
    AudioSource audioSourceEnd;

    private void Start()
    {

        Component[] components = GetComponents<AudioSource>();
        if (components.Length == 2)
        {
            audioSourceStart = (AudioSource)components[0];
            audioSourceStart.playOnAwake = false;
            audioSourceStart.loop = true;

            audioSourceEnd = (AudioSource)components[1];
            audioSourceEnd.playOnAwake = false;
            audioSourceEnd.loop = false;

            if (audioClipStart != null && audioClipEnd != null)
            {
                audioSourceStart.clip = audioClipStart;
                audioSourceEnd.clip = audioClipEnd;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzleFlash.Play();
            if (audioSourceStart != null)
                audioSourceStart.Play();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (audioSourceStart != null)
            {
                audioSourceStart.Stop();
                audioSourceEnd.PlayOneShot(audioClipEnd);

            }
            muzzleFlash.Stop();
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
    }
}


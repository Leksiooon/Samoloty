using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAirPlane : MonoBehaviour
{
    public AudioClip gotFuel;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel"))
        {
            Destroy(other.gameObject);
            FlyThroughRing(other);
        }
    }

    void FlyThroughRing(Collider barrell)
    {
        source.PlayOneShot(gotFuel);
        BarrelBehavior.CreateNewBarrel(barrell);
    }
}

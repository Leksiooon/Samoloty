using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            FlyThroughFuel(other);
            other.SendMessage("HealFuel");
        }
    }

    void FlyThroughFuel(Collider barrell)
    {
        source.PlayOneShot(gotFuel);
        BarrelBehavior.CreateNewBarrel(barrell);
    }
}

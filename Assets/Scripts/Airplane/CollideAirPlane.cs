using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            var fuelValue = other.gameObject.GetComponent<BarrelBehavior>().fuelValue;
            other.SendMessage("HealFuel",fuelValue);
        }
        if (other.gameObject.CompareTag("Terrain"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print("dupa");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FlyThroughFuel(Collider barrell)
    {
        source.PlayOneShot(gotFuel);
        BarrelBehavior.CreateNewBarrel(barrell);
    }
}

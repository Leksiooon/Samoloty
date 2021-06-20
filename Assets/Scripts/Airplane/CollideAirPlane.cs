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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            FlyThroughFuel(collision);
            var fuelValue = collision.gameObject.GetComponent<BarrelBehavior>().fuelValue;
            collision.SendMessage("HealFuel", fuelValue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Tower"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void FlyThroughFuel(Collider barrel)
    {
        source.PlayOneShot(gotFuel);
        BarrelBehavior.CreateNewBarrel(barrel.GetComponent<BarrelBehavior>());
    }
}

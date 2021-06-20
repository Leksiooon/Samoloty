using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 50f;
    public GameObject effectsDestroy;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effects = Instantiate(effectsDestroy, transform.position, Quaternion.LookRotation(Vector3.up));
        effects.GetComponent<Effects>().Play();
        
        Destroy(gameObject,20f);
        Destroy(effects,20f);
    }

}

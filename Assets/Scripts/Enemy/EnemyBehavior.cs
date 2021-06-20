using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 50f;
    public GameObject effectsDestroy;

    Vector3 center;
    bool destroy = false;

    private void Start()
    {
        center = GetComponent<Renderer>().bounds.center;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !destroy)
        {
            destroy = true;
            Die();
        }
    }

    void Die()
    {
        GameObject effects = Instantiate(effectsDestroy, center, Quaternion.LookRotation(Vector3.up));
        effects.GetComponent<Effects>().Play();

        Destroy(gameObject, 20f);
        Destroy(effects, 20f);
    }

}

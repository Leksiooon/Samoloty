using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("¯ycie")]
    public float health = 50f;

    [Header("Efekty koñcowe")]
    GameObject effects;
    public GameObject seedEffectsDestroy;
    private Effects myDestroyEffects;
    public Effects myDestroyEffectsProp { get => myDestroyEffects; }

    bool destroy = false;

    private void Start()
    {
        effects = Instantiate(seedEffectsDestroy, Vector3.zero, Quaternion.LookRotation(Vector3.up));
        myDestroyEffects = effects.GetComponent<Effects>();
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
        effects.transform.position = GetComponent<Renderer>().bounds.center;
        myDestroyEffects.Play();

        Destroy(gameObject, 20f);
        Destroy(effects, 20f);
    }

}

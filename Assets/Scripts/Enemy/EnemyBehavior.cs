using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 50f;
    public GameObject effectsDestroy;

    Vector3 center;
    bool destroy = false;

    public string textValue;
    public Text textElement;

    private void Start()
    {
        center = GetComponent<Renderer>().bounds.center;
        textElement.text = "";
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

        var listEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (listEnemy.Length == 1)
        {
            textElement.text = textValue;
        }

        Destroy(gameObject, 20f);
        Destroy(effects, 20f);
    }

}

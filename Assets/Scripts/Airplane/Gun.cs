using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject plane;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(plane.transform.position, plane.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}


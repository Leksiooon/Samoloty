using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehavior : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, 10);
    }
}

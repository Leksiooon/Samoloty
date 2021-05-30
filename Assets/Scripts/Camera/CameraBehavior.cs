using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    Vector3 offset;
    GameObject airplane;

    void Start()
    {
        airplane = GameObject.FindWithTag("AirPlane");
    }

    void Update()
    {
        offset = airplane.transform.position - airplane.transform.forward * 30.0f + airplane.transform.up * 15.0f;
        Camera.main.transform.position = offset;
        Camera.main.transform.LookAt(airplane.transform.position);
    }
}

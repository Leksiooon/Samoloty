using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_MS : MonoBehaviour
{
    public static Vector3 ABS(Vector3 vector3)
    {
        Vector3 tmp = new Vector3();
        tmp.x = Mathf.Abs(vector3.x);
        tmp.y = Mathf.Abs(vector3.y);
        tmp.z = Mathf.Abs(vector3.z);

        return tmp;
    }
}

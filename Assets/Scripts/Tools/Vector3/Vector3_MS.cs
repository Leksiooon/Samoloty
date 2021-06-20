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

    public static Vector3 spreadVectorXY(Vector3 seedVector, float range)
    {
        Vector3 vector3 = seedVector;
        vector3.x += Random.Range(-range, range);
        vector3.y += Random.Range(-range, range);

        return vector3;
    }
}

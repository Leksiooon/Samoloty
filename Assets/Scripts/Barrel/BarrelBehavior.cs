using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehavior : MonoBehaviour
{
    public float fuelValue = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up, 2);
    }

    public static void CreateNewBarrel(BarrelBehavior barrel)
    {
        GameObject GameTerrain = GameObject.FindGameObjectWithTag("Area");
        var bounds = GameTerrain.GetComponent<Collider>().bounds;

        var newPosition = RandomPointInBounds(bounds);
        barrel.gameObject.transform.position = newPosition;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}

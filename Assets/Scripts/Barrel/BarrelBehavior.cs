using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehavior : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, 2);
    }

    public static void CreateNewBarrel(Collider barrel)
    {
        GameObject GameTerrain = GameObject.Find("Terrain");
        Vector3 Dimensions;
        Dimensions = GameTerrain.GetComponent<Terrain>().terrainData.size;
        float randomX = Random.Range(1, Dimensions.x);
        float randomY = Random.Range(1, Dimensions.y/2);
        float randomZ = Random.Range(1, Dimensions.z);

        var newPosition = new Vector3(randomX, randomY, randomZ);
        Instantiate(barrel, newPosition, barrel.transform.rotation);
    }
}
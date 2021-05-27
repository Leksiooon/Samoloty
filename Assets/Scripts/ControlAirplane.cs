using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAirplane : MonoBehaviour
{
    public float Speed = 100;
    public float SensitiveRotationVertical = 2; // pionowo
    public float SensitiveRotationHorizontal = 3; // poziomo

    GameObject terrain;


    private void Start()
    {
        terrain = GameObject.FindWithTag("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
        transform.Rotate(SensitiveRotationVertical * 0.1f * Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal") * 0.1f * SensitiveRotationHorizontal);

        // wp³yw wznoszenia i opadania na prêdkoœæ
        Speed -= transform.forward.y * Time.deltaTime * 50.0f;
        if (Speed < 50.0f)
        {
            Speed = 50.0f;
        }

        // kolizje z terenem
        float terrainHeightWhereWeAre = (terrain.transform.position - transform.position).y;
        if (terrainHeightWhereWeAre >= 0)
        {
            transform.position = new Vector3(
                transform.position.x,
                terrain.transform.position.y,
                transform.position.z);
        }




    }
}

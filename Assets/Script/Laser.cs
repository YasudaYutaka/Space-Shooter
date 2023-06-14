using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static string TAG = "Laser";

    private float speed = 8;

    void Update()
    {
        MoveUpwards();
        Destroy();
    }

    void MoveUpwards()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void Destroy()
    {
        if (transform.position.y >= 8)
        {
            Destroy(gameObject);
        }
    }
}

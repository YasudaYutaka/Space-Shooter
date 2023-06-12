using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 8;

    void Update()
    {
        MoveUpwards();
        Destroy();
    }

    private void MoveUpwards()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void Destroy()
    {
        if (transform.position.y >= 8)
        {
            Destroy(gameObject);
        }
    }
}

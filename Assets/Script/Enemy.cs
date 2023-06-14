using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();

        if (transform.position.y < -5)
        {
            Respawn();
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Respawn()
    {
        var randomXPosition = Random.Range(-8, 8);
        transform.position = new Vector3(randomXPosition, 7);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Player.TAG)
        {
            OnPlayerHit(other);
        }


        if (other.tag == Laser.TAG)
        {
            OnLaserHit(other);
        }
    }

    void OnPlayerHit(Collider other)
    {
        var player = other.transform.GetComponent<Player>();
        if (player != null)
        {
            player.Damage();
        }
        Destroy(gameObject);
    }

    void OnLaserHit(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

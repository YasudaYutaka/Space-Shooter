using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static string TAG = "Player";

    [SerializeField]
    private short lives = 1;

    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private float fireRateTime = 0.15f;

    private float nextFireTime;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Shoot();
        }
    }

    void CalculateMovement()
    {
        Move();
        LimitSpace();
    }

    void Move()
    {
        var horizontalInput = GetHorizontalInput();
        var verticalInput = GetVerticalInput();
        var direction = new Vector3 (horizontalInput, verticalInput);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    void LimitSpace()
    {
        var positionX = transform.position.x;
        var positionY = transform.position.y;
        LimitHorizontally(positionX, positionY);
        LimitVertically(positionX, positionY);
    }

    void LimitHorizontally(float positionX, float positionY)
    {
        transform.position = new Vector3(positionX, Mathf.Clamp(positionY, -3.8f, 0));
    }

    void LimitVertically(float positionX, float positionY)
    {
        if (positionX > 11.3f)
        {
            transform.position = new Vector3(-11.3f, positionY);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, positionY);
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRateTime;
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.8f), Quaternion.identity);
    }

    public void Damage()
    {
        lives--;

        if (lives == 0)
        {
            spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private GameObject laserPrefab;

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

    private void CalculateMovement()
    {
        Move();
        LimitSpace();
    }

    private void Move()
    {
        var horizontalInput = GetHorizontalInput();
        var verticalInput = GetVerticalInput();
        var direction = new Vector3 (horizontalInput, verticalInput);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    private float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    private void LimitSpace()
    {
        var positionX = transform.position.x;
        var positionY = transform.position.y;
        LimitHorizontally(positionX, positionY);
        LimitVertically(positionX, positionY);
    }

    private void LimitHorizontally(float positionX, float positionY)
    {
        transform.position = new Vector3(positionX, Mathf.Clamp(positionY, -3.8f, 0));
    }

    private void LimitVertically(float positionX, float positionY)
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

    private void Shoot()
    {
        
        nextFireTime = Time.time + fireRateTime;
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.8f), Quaternion.identity);
    }

}

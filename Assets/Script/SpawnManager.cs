using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    private bool keepSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (keepSpawning)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), Quaternion.identity, enemyContainer.transform);
            yield return new WaitForSeconds(5);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        var randomXPosition = Random.Range(-8, 8);
        return new Vector3(randomXPosition, 7);
    }

    public void OnPlayerDeath()
    {
        keepSpawning = false;
    }
}

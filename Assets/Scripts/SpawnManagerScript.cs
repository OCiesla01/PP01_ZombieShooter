using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerScript : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject powerup;

    private int powerupSpawnRate = 10;
    private int enemySpawnRate = 2;

    private float powerupXBorder = 19.0f;
    private float powerupZBorder = 9.5f;
    private float enemyXBorder = 23.5f;
    private float enemyZBorder = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", 5, powerupSpawnRate);
        InvokeRepeating("SpawnRandomEnemy", 2, enemySpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        float xRange = Random.Range(-enemyXBorder, enemyXBorder);
        float zRange = Random.Range(-enemyZBorder, enemyZBorder);

        Vector3 firstPosition = new Vector3(enemyXBorder, 0.5f, zRange);
        Vector3 secondPosition = new Vector3(xRange, 0.5f, enemyZBorder);

        int randomIndex = Random.Range(0, enemies.Length);
        int randomPick = Random.Range(0, 2);

        Vector3 chosenPosition = (randomPick == 0) ? firstPosition : secondPosition;

        Instantiate(enemies[randomIndex], chosenPosition, enemies[randomIndex].transform.rotation);
    }

    void SpawnPowerup()
    {
        float xPosition = Random.Range(-powerupXBorder, powerupXBorder);
        float zPosition = Random.Range(-powerupZBorder, powerupZBorder);

        Vector3 randomPosition = new Vector3(xPosition, 0, zPosition);

        Instantiate(powerup, randomPosition, powerup.transform.rotation);
    }
}

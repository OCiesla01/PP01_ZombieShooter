using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject powerup;
    [SerializeField] private PlayerScript playerScript;

    private int powerupSpawnRate = 10;
    private int enemySpawnRate = 2;

    private float powerupXBorder = 19.0f;
    private float powerupZBorder = 9.5f;
    private float enemyXBorder = 23.5f;
    private float enemyZBorder = 15.0f;    

    void Start()
    {
        InvokeRepeating("SpawnPowerup", 5, powerupSpawnRate);
        InvokeRepeating("SpawnRandomEnemy", 2, enemySpawnRate);
    }

    float GenerateRandomPosition(float firstBound, float secondBound)
    {
        return Random.Range(firstBound, secondBound);
    }
    void SpawnRandomEnemy()
    {
        if (playerScript.isAlive)
        {
            float xRange = GenerateRandomPosition(-enemyXBorder, enemyXBorder);
            float zRange = GenerateRandomPosition(-enemyZBorder, enemyZBorder);

            Vector3 firstPosition = new Vector3(enemyXBorder, 0.5f, zRange);
            Vector3 secondPosition = new Vector3(xRange, 0.5f, enemyZBorder);

            int randomIndex = Random.Range(0, enemies.Length);
            int randomPick = Random.Range(0, 2);

            Vector3 chosenPosition = (randomPick == 0) ? firstPosition : secondPosition;

            Instantiate(enemies[randomIndex], chosenPosition, enemies[randomIndex].transform.rotation);
        }   
    }

    void SpawnPowerup()
    {
        if (playerScript.isAlive)
        {
            float xPosition = GenerateRandomPosition(-powerupXBorder, powerupXBorder);
            float zPosition = GenerateRandomPosition(-powerupZBorder, powerupZBorder);

            Vector3 randomPosition = new Vector3(xPosition, 0, zPosition);

            Instantiate(powerup, randomPosition, powerup.transform.rotation);
        }
    }

    public void UpdateZombiesSpeed()
    {
        foreach (var prefab in enemies)
        {
            MoveTowardsPlayerScript script = prefab.GetComponent<MoveTowardsPlayerScript>();

            script.moveSpeed += .175f;
        }
    }
}

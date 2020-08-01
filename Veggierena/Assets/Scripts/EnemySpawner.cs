using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3[] spawnLocs; 

    public float startDelay;
    public float spawnDelay;

    Vector3 NorthSpawnLoc;
    Vector3 SouthSpawnLoc;
    Vector3 WestSpawnLoc;
    Vector3 EastSpawnLoc; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay); 
    }

    void SpawnEnemy()
    {
        int enemIndex = Random.Range(0, enemies.Length);
        int locationIndex = Random.Range(0, spawnLocs.Length);

        Debug.Log("Spawning a " + enemies[enemIndex] + " at " + spawnLocs[locationIndex]);

        GameObject newEnemy = Instantiate(enemies[enemIndex], spawnLocs[locationIndex], enemies[enemIndex].transform.rotation);

        switch (locationIndex)
        {
            case 0: newEnemy.GetComponent<EnemyController>().north = true; break;
            case 1: newEnemy.GetComponent<EnemyController>().south = true; break;
            case 2: newEnemy.GetComponent<EnemyController>().east = true; break;
            case 3: newEnemy.GetComponent<EnemyController>().west = true; break;
        }
    }
}

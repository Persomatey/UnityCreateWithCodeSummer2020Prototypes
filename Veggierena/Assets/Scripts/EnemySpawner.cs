using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3[] spawnLocs; 

    public float startDelay;
    public float spawnDelay;

    private int spawn1Ago;
    private int spawn2Ago;
    private int enemIndex; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay);
        spawn1Ago = 5;
        spawn2Ago = 6; 
    }

    void SpawnEnemy()
    {
        if (!GameObject.Find("Player").GetComponent<PlayerController>().deathState)
        {
            int locationIndex = Random.Range(0, spawnLocs.Length);

            spawn2Ago = spawn1Ago;
            spawn1Ago = enemIndex;
            enemIndex = Random.Range(0, enemies.Length);

            if (spawn1Ago == spawn2Ago && enemIndex == spawn1Ago)
            {
                Debug.Log("Too many " + enemies[enemIndex] + " in a row. Changing index. ");
                if (enemIndex < 2)
                {
                    enemIndex++;
                }
                else
                {
                    enemIndex--;
                }
            }

            Debug.Log("Spawning a " + enemies[enemIndex] + " at " + spawnLocs[locationIndex]);

            GameObject newEnemy = Instantiate(enemies[enemIndex], spawnLocs[locationIndex], enemies[enemIndex].transform.rotation);

            switch (locationIndex)
            {
                case 0: newEnemy.GetComponent<EnemyController>().northB = true; break;
                case 1: newEnemy.GetComponent<EnemyController>().southB = true; break;
                case 2: newEnemy.GetComponent<EnemyController>().eastB = true; break;
                case 3: newEnemy.GetComponent<EnemyController>().westB = true; break;
            }
        }
    }
}

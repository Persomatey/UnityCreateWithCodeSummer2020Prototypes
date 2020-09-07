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

            GameObject newEnemy = Instantiate(enemies[enemIndex], new Vector3(spawnLocs[locationIndex].x, enemies[enemIndex].transform.position.y, spawnLocs[locationIndex].z), enemies[enemIndex].transform.rotation);

            switch (locationIndex)
            {
                case 0:
                    if (newEnemy.name == "PeaStalk(Clone)")
                    { newEnemy.GetComponent<EnemyPeaController>().northB = true; }
                    else
                    { newEnemy.GetComponent<EnemyController>().northB = true; }
                    break;
                case 1:
                    if (newEnemy.name == "PeaStalk(Clone)")
                    { newEnemy.GetComponent<EnemyPeaController>().southB = true; }
                    else
                    { newEnemy.GetComponent<EnemyController>().southB = true; }
                    break;
                case 2:
                    if (newEnemy.name == "PeaStalk(Clone)")
                    { newEnemy.GetComponent<EnemyPeaController>().eastB = true; }
                    else
                    { newEnemy.GetComponent<EnemyController>().eastB = true; }
                    break;
                case 3:
                    if (newEnemy.name == "PeaStalk(Clone)")
                    { newEnemy.GetComponent<EnemyPeaController>().westB = true; }
                    else
                    { newEnemy.GetComponent<EnemyController>().westB = true; }
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab; 

    private float spawnRange = 9.0f;
    private int enemyCount;
    public int waveNum; 

    void Start()
    {
        waveNum = 1; 
        SpawnEnemyWave(waveNum);
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;

        if (enemyCount == 0)
        {
            waveNum++;
            SpawnEnemyWave(waveNum);
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randSpawnPos; 
    }
}

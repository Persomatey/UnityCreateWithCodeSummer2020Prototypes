using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;

    private Vector3 spawnPos;

    private float startDelay = 1.5f;
    private float repeatRate = 1;

    private PlayerController playerScript;

    void Start()
    {
        spawnPos = new Vector3(25, 0, 0);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        int rand = Random.Range(0, 3); 

        if (playerScript.gameOver == false)
        {
            switch(rand)
            {
                case 0: Instantiate(obstaclePrefab1, spawnPos, obstaclePrefab1.transform.rotation); break;
                case 1: Instantiate(obstaclePrefab2, spawnPos, obstaclePrefab2.transform.rotation); break;
                case 2: Instantiate(obstaclePrefab3, spawnPos, obstaclePrefab3.transform.rotation); break;
            }
        }
    }
}

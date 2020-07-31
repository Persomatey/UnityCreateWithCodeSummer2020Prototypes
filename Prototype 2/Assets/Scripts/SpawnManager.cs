using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject horsePrefabLeft;
    public GameObject horsePrefabRight;
    public GameObject barInst; 

    public int lastF;
    public int lastS;

    private float spawnRangeZ = 20.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f; 

    void Start()
    {
        lastF = 100;
        lastS = 100;

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnHorse", startDelay * 2, spawnInterval * 2);
    }

    void SpawnRandomAnimal()
    {
        // Randomly choose an animal 
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Ensure that it doesn't choose the same animal thrice in a row 
        lastS = lastF;
        lastF = animalIndex;
        if (animalIndex == lastF && animalIndex == lastS && animalIndex < 2)
        {
            animalIndex++;
        }
        else if (animalIndex == lastF && animalIndex == lastS && animalIndex == 2)
        {
            animalIndex = 0;
        }

        // Randomly choose a location for spawn 
        Vector3 spawnPos = new Vector3(-15, 0, Random.Range(-spawnRangeZ, spawnRangeZ));

        // Instantiate animal prefab 
        GameObject animal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        GameObject bar = Instantiate(barInst, spawnPos, barInst.transform.rotation);

        animal.GetComponent<AnimalHealth>().bar = bar; 
    }

    void SpawnHorse()
    {
        int horseIndex = Random.Range(8, 12);
        bool spawnDir = (Random.value < 0.5f);
        Vector3 pos = new Vector3(horseIndex, 0, 0); 
        
        if (spawnDir)
        {
            pos.z = -28; 
            Instantiate(horsePrefabLeft, pos, horsePrefabLeft.transform.rotation);
        }
        else
        {
            pos.z = 28;
            Instantiate(horsePrefabRight, pos, horsePrefabRight.transform.rotation);
        }
    }
}

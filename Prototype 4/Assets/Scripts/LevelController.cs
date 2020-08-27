using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private GameObject deathObj1;
    private GameObject deathObj2;
    private GameObject deathObj3;
    private GameObject deathObj4;

    public Transform playerTrans;

    private List<GameObject> enemies = new List<GameObject>();
    private string nameToAdd = "Enemy(Clone)";

    private bool doOnce;

    private Text waveDis;

    void Start()
    {
        deathObj1 = GameObject.Find("GameOverImage");
        deathObj2 = GameObject.Find("GameOverText");
        deathObj3 = GameObject.Find("RetryButton");
        deathObj4 = GameObject.Find("MainMenuButton");

        waveDis = GameObject.Find("WaveNum").GetComponent<Text>();  

        deathObj1.SetActive(false);
        deathObj2.SetActive(false);
        deathObj3.SetActive(false);
        deathObj4.SetActive(false);

        playerTrans = GameObject.Find("Player").transform;

        doOnce = false; 
    }

    private void Update()
    {
        if (playerTrans.position.y < -2 && doOnce == false)
        {
            GameOver();
            Debug.Log("Player's Y-coord is " + playerTrans.position.y + " so calling GameOver()");
            doOnce = true; 
        }

        waveDis.text = "" + GameObject.Find("SpawnManager").GetComponent<SpawnManager>().waveNum;
    }

    void GameOver()
    {
        deathObj1.SetActive(true);
        deathObj2.SetActive(true);
        deathObj3.SetActive(true);
        deathObj4.SetActive(true);

        StopEnemies(); 
    }

    void StopEnemies()
    {
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name == nameToAdd)
            {
                enemies.Add(go);

                Debug.Log("Added " + go.name + " to enemies[]"); 
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyScript>().enabled = false;

            Debug.Log("Disabling " + enemies[i].name + "'s script");
        }
    }
}

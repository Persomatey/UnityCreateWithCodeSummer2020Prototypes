using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOver1;
    public GameObject gameOver2;
    public GameObject gameOver3;
    public GameObject gameOver4;

    public GameObject start1;
    public GameObject start2;
    public GameObject start3;
    public GameObject start4;
    public GameObject start5;

    public TextMeshProUGUI scoreText;

    private float spawnRate;
    public List<GameObject> targets;

    private int score; 

    private int last1;
    private int last2;

    bool keepSpawning; 

    public void StartGame(float passed)
    {
        keepSpawning = true;
        UpdateScore(0);

        last1 = 99;
        last2 = 99;

        score = 0;

        spawnRate = passed; 

        StartCoroutine(SpawnTarget());

        start1.SetActive(false);
        start2.SetActive(false);
        start3.SetActive(false);
        start4.SetActive(false);
        start5.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    IEnumerator SpawnTarget()
    {
        while(keepSpawning)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = targetIndex();

            Instantiate(targets[index]);

            UpdateScore(5); 
        }
    }

    int targetIndex()
    {
        int ret; 

        ret = Random.Range(0, targets.Count);

        if (ret == last1 && last1 == last2)
        {
            //Debug.Log("<color=red>" + "DUPLICATE" + "</color> " + last2 + " | " + last1 + " | " + "<color=red>" + ret + "</color>");
            if (ret == (targets.Count - 1))
            {
                ret--;
                last2 = last1;
                last1 = ret;
                //Debug.Log("<color=yellow>" + ret + "</color> (decremented)");
                return ret; 
            }
            else
            {
                ret++;
                last2 = last1;
                last1 = ret;
                //Debug.Log("<color=yellow>" + ret + "</color> (incremented)");
                return ret;
            }
        }
        else
        {
            //Debug.Log(last2 + " | " + last1 + " | " + "<color=green>" + ret + "</color>");
            last2 = last1;
            last1 = ret;
            return ret;
        }
    }

    public void GameOver()
    {
        keepSpawning = false;
        gameOver1.SetActive(true);
        gameOver2.SetActive(true);
        gameOver3.SetActive(true);
        gameOver4.SetActive(true);
    }
}

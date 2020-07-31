using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class OutOfBounds : MonoBehaviour
{
    private float lowerBound = 13;

    public GameObject gameOverAsset1;
    public GameObject gameOverAsset2;
    public GameObject gameOverAsset3;

    private void Start()
    {
        gameOverAsset1 = GameObject.Find("GameOverText"); 
        gameOverAsset2 = GameObject.Find("PtsText");
        gameOverAsset3 = GameObject.Find("Image");
    }

    void Update()
    {
        if (transform.position.x > lowerBound)
        {
            Destroy(gameObject);

            GameObject.Find("Player").GetComponent<PlayerController>().DecrementHealth();
        }
    }
}

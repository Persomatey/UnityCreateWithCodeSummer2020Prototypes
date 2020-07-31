using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizInput;
    public float vertInput;
    public float speed = 25;
    public float zRange = 20;
    public float xRange = 2;
    public int health = 3;
    public GameObject projectilePrefab;

    public GameObject gameOverAsset1;
    public GameObject gameOverAsset2;
    public GameObject gameOverAsset3;
    public Text healthText; 

    private void Start()
    {
        gameOverAsset1 = GameObject.Find("GameOverText");
        gameOverAsset2 = GameObject.Find("PtsText");
        gameOverAsset3 = GameObject.Find("Image");
    }

    void Update()
    {
        if (GameObject.Find("GameController").GetComponent<PointSystem>().isGameOver == false)
        {
            horizInput = Input.GetAxis("Horizontal");
            vertInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * horizInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);

            if (transform.position.z < -zRange)
            {
                transform.position = new Vector3(transform.position.x, 0, -zRange);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, 0, zRange);
            }

            if (transform.position.x < 10 - xRange)
            {
                transform.position = new Vector3(10 - xRange, 0, transform.position.z);
            }

            if (transform.position.x > 10 + xRange)
            {
                transform.position = new Vector3(10 + xRange, 0, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 pos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
                Instantiate(projectilePrefab, pos, projectilePrefab.transform.rotation);
            }
        }

        if (health == 0)
        {
            if (gameOverAsset1.transform.localPosition.x != 0)
            {
                gameOverAsset1.transform.localPosition = new Vector3(0, 75, 0);
                gameOverAsset2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                gameOverAsset2.transform.localPosition = new Vector3(0, -100, 0);
                gameOverAsset3.transform.localPosition = new Vector3(0, 0, 0);
            }

            GameObject.Find("GameController").GetComponent<PointSystem>().isGameOver = true;
        }

        if (health < 0)
        {
            health = 0;
            healthText.text = health + " HP";
        }
    }

    public void DecrementHealth()
    {
        Debug.Log("Decrementing Health"); 
        health = health - 1;
        healthText.text = health + " HP";
        Debug.Log("Health now at " + health); 
    }
}

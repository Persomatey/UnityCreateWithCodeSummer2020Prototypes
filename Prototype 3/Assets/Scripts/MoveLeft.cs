using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public bool isObstacle;
    private PlayerController playerScript; 

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    void Update()
    {
        if(playerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (isObstacle && transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}

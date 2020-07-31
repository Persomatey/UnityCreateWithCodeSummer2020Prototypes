using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float modifier; 
    public bool isObstacle;
    private PlayerController playerScript; 

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
        modifier = 1; 
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            modifier = 2; 
        }
        else
        {
            modifier = 1; 
        }

        if(playerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * modifier);
        }

        if (isObstacle && transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}

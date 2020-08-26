using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDir; 

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        lookDir = (player.transform.position - transform.position).normalized;
    }

    void Update()
    {
        lookDir = (player.transform.position - transform.position).normalized; 
        enemyRb.AddForce( lookDir * speed ); 

        if (transform.position.y < - 15)
        {
            Destroy(gameObject); 
        }
    }
}

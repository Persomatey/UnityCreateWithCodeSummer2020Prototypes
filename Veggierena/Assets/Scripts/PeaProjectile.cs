using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaProjectile : MonoBehaviour
{
    public GameObject playerObj;
    public Vector3 playerLoc;
    public float speed;
    private bool isDangerous;
    private Vector3 direction;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        playerLoc = GameObject.Find("Player").transform.position;
        isDangerous = false; 
        Invoke("FlipCol", 0.5f); 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerLoc.x, transform.position.y, playerLoc.z), Time.deltaTime * speed);

        if (transform.position.x == playerLoc.x && transform.position.z == playerLoc.z)
        {
            Destroy(gameObject); 
        }
    }

    void FlipCol()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
        isDangerous = true; 
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" && isDangerous)
        {
            playerObj.GetComponent<PlayerController>().HurtHealth(1);
            direction = (col.transform.position - transform.position).normalized;
            col.gameObject.GetComponent<PlayerController>().PushPlayer(direction);

            Invoke("ResetBool", 0.1f);
        }
    }
}

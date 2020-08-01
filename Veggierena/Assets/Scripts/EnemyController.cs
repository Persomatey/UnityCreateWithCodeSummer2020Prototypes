using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject playerObj;
    public Vector3 playerPos; 
    Vector3 enemyPos;
    Vector3 nextPos; 

    public int health;
    public float speed; 
    public bool wasHit;

    public bool active;
    public bool north;
    public bool south;
    public bool west;
    public bool east; 

    void Start()
    {
        playerObj = GameObject.Find("Player");
        Invoke("ActivateEnemy", 1.5f); 
    }

    void Update()
    {
        if (active)
        {
            enemyPos = transform.position; 
            playerPos = GameObject.Find("Player").GetComponent<Transform>().position; 
            nextPos = new Vector3(playerPos.x, enemyPos.y, playerPos.z); 
        }

        else
        {
            if (north)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
            else if (south)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (west)
            {
                transform.Translate(-Vector3.left * Time.deltaTime * speed);
            }
            else if (east)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (!wasHit && !playerObj.GetComponent<PlayerController>().deathState && active)
        {
            transform.position = Vector3.MoveTowards(enemyPos, nextPos, Time.deltaTime * speed);    // moves enemy to position designated by nextPos variable
        }

        if (health <= 0)
        {
            GameObject.Find("LevelController").GetComponent<ArenaController>().IncreaseKills(); 
            Destroy(gameObject); 
        }
    }

    void ActivateEnemy()
    {
        active = true; 
    }

    public void DamageEnemy(int dam)
    {
        health -= dam;
        wasHit = true;
        Invoke("ResetBool", 0.2f); 
    }

    void ResetBool()
    {
        wasHit = false; 
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            playerObj.GetComponent<PlayerController>().HurtHealth(1); 
        }
    }
}

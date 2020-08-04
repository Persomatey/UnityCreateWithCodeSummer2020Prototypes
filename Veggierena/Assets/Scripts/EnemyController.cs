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

    private AudioSource source;
    public AudioClip hitSFX;
    public AudioClip dyingSFX; 

    public int health;
    public float speed; 
    public bool wasHit;

    public bool active;
    public bool northB;
    public bool southB; 
    public bool westB;
    public bool eastB;

    private Vector3 direction;

    private bool increaseKillsOnce;
    private bool isDead;

    public GameObject healthPickup;
    public GameObject atkPickup; 

    void Start()
    {
        source = GetComponent<AudioSource>(); 
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
            if (northB)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
            else if (southB)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (westB)
            {
                transform.Translate(-Vector3.left * Time.deltaTime * speed);
            }
            else if (eastB)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (!wasHit && !playerObj.GetComponent<PlayerController>().deathState && active && !isDead)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = Vector3.MoveTowards(enemyPos, nextPos, Time.deltaTime * speed); 
        }

        if (health <= 0)
        {
            if (!increaseKillsOnce)
            {
                GameObject.Find("LevelController").GetComponent<ArenaController>().IncreaseKills();
                gameObject.GetComponent<Collider>().enabled = false; 
                increaseKillsOnce = true;
                isDead = true;
                source.PlayOneShot(dyingSFX, 1.0f); 
            }

            if (gameObject.transform.localScale.y > 0.075f)
            {
                gameObject.transform.localScale += new Vector3(0, -0.025f, 0);
                gameObject.transform.position += new Vector3(0, -0.025f, 0); 
            }
            else if (gameObject.transform.localScale.y <= 0.075f)
            {
                Invoke("DelayedKill", 0.5f); 
            }
        }
    }

    void DelayedKill()
    {
        int rand = Random.Range(0, 11); 
        
        switch (rand)
        {
            case 0: 
                Debug.Log("Dropping Health Pickup"); 
                Instantiate(healthPickup, transform.position, healthPickup.transform.rotation); break;
            case 1:
                Debug.Log("Dropping Attack Pickup");
                Instantiate(atkPickup, transform.position, atkPickup.transform.rotation); break;
        }

        Destroy(gameObject);
    }

    void ActivateEnemy()
    {
        active = true; 
    }

    public void DamageEnemy(int dam)
    {
        source.PlayOneShot(hitSFX, 1.0f); 
        health -= dam;
        wasHit = true;
        Invoke("ResetBool", 0.2f); 
    }

    void ResetBool()
    {
        wasHit = false; 
    }

    void HurtPlayer()
    {
        playerObj.GetComponent<PlayerController>().HurtHealth(1);
        wasHit = true;
        Invoke("ResetBool", 0.1f);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            playerObj.GetComponent<PlayerController>().HurtHealth(1);
            direction = (col.transform.position - transform.position).normalized;
            col.gameObject.GetComponent<PlayerController>().PushPlayer(direction);

            Invoke("ResetBool", 0.1f);
            wasHit = true; 
        }
    }

    public void PushEnemy(Vector3 direction)
    {
        //StartCoroutine(Please(direction));
        GetComponent<Rigidbody>().AddForce(direction * 200);
        Invoke("StopVelocity", 0.2f);
    }

    public void StopVelocity()
    {
        Debug.Log("Stopping Velocity");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}

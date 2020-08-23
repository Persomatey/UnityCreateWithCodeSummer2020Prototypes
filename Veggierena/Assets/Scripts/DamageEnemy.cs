﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public bool isActive; 
    int damage;
    int modifier;
    private Vector3 direction;

    void Start()
    {
        damage = 1;

        Collider collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
        collider.enabled = true;

        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
    }

    void Update()
    {
        modifier = GameObject.Find("Player").GetComponent<PlayerController>().damModifier;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy" && isActive)
        {
            int dam = damage * modifier;
            Debug.Log("ENEMY! Doing " + dam + " damage...");
            col.GetComponent<EnemyController>().DamageEnemy(dam);
            isActive = false;

            direction = (col.transform.position - transform.position).normalized;
            col.gameObject.GetComponent<EnemyController>().PushEnemy(direction);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy" && isActive)
        {
            int dam = damage * modifier;
            Debug.Log("ENEMY! Doing " + dam + " damage...");
            col.GetComponent<EnemyController>().DamageEnemy(dam);
            isActive = false;

            direction = (col.transform.position - transform.position).normalized;
            col.gameObject.GetComponent<EnemyController>().PushEnemy(direction);
        }
    }

    public void ActivateBool() 
    {
        isActive = true;
        Invoke("ResetBool", 0.1f);
    }

    void ResetBool() 
    {
        isActive = false;
    }
}
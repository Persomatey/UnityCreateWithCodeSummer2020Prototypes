using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private AudioSource source;

    public bool isHealth;
    public bool isAttack; 

    void Start()
    {
        source = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Something collided"); 
        if(col.gameObject.tag == "Player")
        {
            if (isHealth)
            {
                Debug.Log("Increasing Health");
                col.GetComponent<PlayerController>().HealHealth(1);
                Destroy(gameObject);
            }

            if (isAttack)
            {
                Debug.Log("Increasing Attack");
                col.GetComponent<PlayerController>().RaiseDamModifier();
                Destroy(gameObject);
            }
        }
    }
}

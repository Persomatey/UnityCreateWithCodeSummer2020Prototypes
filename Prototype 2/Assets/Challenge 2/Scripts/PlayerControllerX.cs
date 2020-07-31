using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool isSpawnable; 

     void Start()
     {
        isSpawnable = true;
     }

    void Update()
    {
        // On spacebar press, send dog
        if ( Input.GetKeyDown(KeyCode.Space) && isSpawnable)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            isSpawnable = false;
            Invoke("ResetBool", 0.5f);
        }
    }

    void ResetBool()
    {
        isSpawnable = true; 
    }
}

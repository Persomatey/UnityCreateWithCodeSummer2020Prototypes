using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float deathTime = 5.0f; 
    public float speed = 40.0f;
    public bool isCookie; 

    private void Start()
    {
        if (isCookie)
        {
            Destroy(gameObject, deathTime);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); 
    }
}

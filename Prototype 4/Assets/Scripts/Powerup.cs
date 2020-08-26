using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float rotSpeed;
    public float moveSpeed; 
    private bool isUp; 

    void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }

        if (transform.position.y >= 0.3)
        {
            isUp = false; 
        }

        if (transform.position.y <= -0.3)
        {
            isUp = true;
        }

    }
}

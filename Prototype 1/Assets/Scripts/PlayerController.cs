using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool isBlueVehicle;
    private bool hasWon;
    private bool hasJumped; 

    void Start()
    {
        Debug.Log("PlayerController.cs Started"); 
    }

    void Update()
    {
        // Gets the controls from the controls menu found in Edit > Project Settings > Input > Axes 
        if (!isBlueVehicle)
        {
            horizontalInput = Input.GetAxis("HorizontalRed");
            forwardInput = Input.GetAxis("VerticalRed");
        }
        else
        {
            horizontalInput = Input.GetAxis("HorizontalBlue");
            forwardInput = Input.GetAxis("VerticalBlue");
        }

        // Move the car forward when pressing forward or turn the car when pressing turn 
        if(!hasWon)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }
        
        if(forwardInput != 0 && !hasWon)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }

        if(transform.position.z > 180 && !hasJumped)
        {
            hasWon = true;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
            hasJumped = true; 
        }
    }
}

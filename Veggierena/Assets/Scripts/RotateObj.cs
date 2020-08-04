using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public bool rotateX;
    public bool rotateY;
    public float rotSpeed;

    public bool destroyObj;
    public float destroyTime;

    void Start()
    {
        if(destroyObj)
        {
            Destroy(gameObject, destroyTime); 
        }
    }

    void Update()
    {
        if(rotateX)
        {
            gameObject.transform.Rotate( Vector3.up * rotSpeed );
        }

        if (rotateY)
        {
            gameObject.transform.Rotate( Vector3.left * rotSpeed );
        }
    }
}

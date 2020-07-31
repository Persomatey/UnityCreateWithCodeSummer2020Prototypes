using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    private Vector3 spinRate = new Vector3(0,0,4000); 

    void Update()
    {
        transform.Rotate(Time.deltaTime * spinRate); 
    }
}

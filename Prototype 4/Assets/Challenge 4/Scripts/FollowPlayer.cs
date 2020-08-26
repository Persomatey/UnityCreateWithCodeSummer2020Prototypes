using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject playerObj;

    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = playerObj.transform.position;
        transform.rotation = new Quaternion(transform.rotation.x, playerObj.transform.rotation.y - 180, transform.rotation.z, transform.rotation.w); 
    }
}
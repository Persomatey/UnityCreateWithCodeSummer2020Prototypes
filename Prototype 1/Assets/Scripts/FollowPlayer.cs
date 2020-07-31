using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject playerObj;
    public string playerName; 

    private Vector3 offset = new Vector3(0, 5, -10); 

    void Start()
    {
        Debug.Log("FollowPlayer.cs Started");
        playerObj = GameObject.Find(playerName); 
    }

    void Update()
    {
        transform.position = playerObj.transform.position + offset;
        
    }
}

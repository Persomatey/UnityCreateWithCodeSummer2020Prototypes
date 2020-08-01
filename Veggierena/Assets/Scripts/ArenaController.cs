using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    public int enemiesKilled; 

    public void IncreaseKills()
    {
        enemiesKilled++; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour
{
    public int enemiesKilled;
    public Text killText;

    void Update()
    {
        killText.text = "Enemies Defeated: " + enemiesKilled; 
    }

    public void IncreaseKills()
    {
        enemiesKilled++; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int pts;
    public Text pntText;
    public bool isGameOver; 

    void Start()
    {
        pntText.text = pts + " Points"; 
    }

    public void UpdatePointTotal(int pointWorth)
    {
        if(!isGameOver)
        {
            pts += pointWorth;
            pntText.text = pts + " Points";
        }
    }
}

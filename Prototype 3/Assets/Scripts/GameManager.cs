using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreTextField; 

    void Update()
    {
        scoreTextField.text = "Score:" + score + "";
    }
}

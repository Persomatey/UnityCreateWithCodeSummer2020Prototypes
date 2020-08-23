using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadPrototype()
    {
        SceneManager.LoadScene("Prototype 3");
    }
    public void LoadChallenge()
    {
        SceneManager.LoadScene("Challenge 3");
    }
}
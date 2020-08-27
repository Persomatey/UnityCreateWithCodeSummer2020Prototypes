using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadPrototype()
    {
        SceneManager.LoadScene("Prototype 4");
    }

    public void LoadChallenge()
    {
        SceneManager.LoadScene("Challenge 4");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

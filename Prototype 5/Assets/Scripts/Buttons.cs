using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Buttons : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>(); 
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void LoadPrototype()
    {
        SceneManager.LoadScene("Prototype 5");
    }

    public void LoadChallenge()
    {
        SceneManager.LoadScene("Challenge 5");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EasyButton()
    {
        gameController.StartGame(1); 
    }

    public void MediumButton()
    {
        gameController.StartGame(0.75f);
    }

    public void HardButton()
    {
        gameController.StartGame(0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip selectionSFX;
    public AudioClip NopeSFX; 

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    public void LoadMainMenu()
    {
        playerAudio.PlayOneShot(selectionSFX, 1.0f);
        Invoke("LoadMainMenu2", 2.0f); 
    }

    void LoadMainMenu2()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadArena()
    {
        playerAudio.PlayOneShot(selectionSFX, 1.0f);
        Invoke("LoadArena2", 0.55f);
    }

    void LoadArena2()
    {
        SceneManager.LoadScene("Arena");
    }

    public void CloseGame()
    {
        playerAudio.PlayOneShot(selectionSFX, 1.0f);
        Invoke("CloseGame2", 0.18f);
    }

    void CloseGame2()
    {
        Application.Quit();
    }


}

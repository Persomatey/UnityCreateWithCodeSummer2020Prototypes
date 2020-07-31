using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public bool isCookie;
    public bool isHorse;
    public bool isHungry; 
    private bool canDestroy; 

    public GameObject gameOverAsset1;
    public GameObject gameOverAsset2;
    public GameObject gameOverAsset3;

    private void Start()
    {
        gameOverAsset1 = GameObject.Find("GameOverText");
        gameOverAsset2 = GameObject.Find("PtsText");
        gameOverAsset3 = GameObject.Find("Image");
        canDestroy = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(isHorse && col.gameObject.name == "Player")
        {
            Debug.Log("Ran into player");

            GameObject.Find("Player").GetComponent<PlayerController>().DecrementHealth();

            canDestroy = false; 
        }

        if(isHungry && col.gameObject.name == "Player")
        {
            Debug.Log("Ran into player");

            GameObject.Find("Player").GetComponent<PlayerController>().DecrementHealth();

            canDestroy = false;
        }

        if (isCookie)
        {
            //GameObject.Find("GameController").GetComponent<PointSystem>().UpdatePointTotal(); 
            col.GetComponent<AnimalHealth>().DecrementHunger();
            canDestroy = false;
            Destroy(gameObject); 
        }

        if(canDestroy == true)
        {
            Debug.Log("Destroying"); 
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}

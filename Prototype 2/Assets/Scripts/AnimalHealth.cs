using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    public int hungerMax; 
    public int hunger;
    public int pointWorth;
    public GameObject bar;
    private Transform barScale; 
    Vector3 barPos;

    void Start()
    {
        barScale = bar.transform.Find("RedBarParent").transform;
    }

    void Update()
    {
        if ( hunger <= 0 )
        {
            GameObject.Find("GameController").GetComponent<PointSystem>().UpdatePointTotal(pointWorth);
            Destroy(bar); 
            Destroy(gameObject); 
        }

        barPos = new Vector3(transform.position.x - 2.5f, 5, transform.position.z); 
        bar.transform.position = barPos; 
    }

    public void DecrementHunger()
    {
        hunger = hunger - 1;
        float tempFloat = (float)hunger / (float)hungerMax;
        Debug.Log("tempFloat is = " + tempFloat); 
        barScale.localScale = new Vector3(barScale.localScale.x, barScale.localScale.y, tempFloat);
    }

    public void SetBar(GameObject rec)
    {
        bar = rec;
    }
}

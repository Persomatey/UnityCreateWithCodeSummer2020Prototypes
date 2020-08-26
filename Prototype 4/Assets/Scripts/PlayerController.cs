using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 15;
    public GameObject powerupInd; 

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint"); 
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupInd.transform.position = new Vector3(transform.position.x, powerupInd.transform.position.y, transform.position.z); 
    }

    void OnTriggerEnter(Collider col)
    {
        if ( col.CompareTag("Powerup") )
        {
            Debug.Log("Pickup Picked Up!");
            hasPowerup = true;
            powerupInd.gameObject.SetActive(true); 
            Destroy(col.gameObject);
            StartCoroutine(PowerupCountdownRoutine()); 
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        hasPowerup = false;
        powerupInd.gameObject.SetActive(false);
        Debug.Log("Powering down player");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 bumpDir = col.transform.position - transform.position;

            enemyRb.AddForce(bumpDir * powerupStrength, ForceMode.Impulse); 
            Debug.Log("Bumped into " + col.gameObject.name + " while hasPowerup is set to " + hasPowerup); 
        }
    }
}

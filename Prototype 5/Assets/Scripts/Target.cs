using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameController gameController;
    public ParticleSystem explosionParticle; 

    public int pointVal; 
    private float minSpeed = 12;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2; 

    void Start()
    {
        transform.position = randSpawnPos();

        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce( randForce(), ForceMode.Impulse );
        targetRb.AddTorque( randTorque(), randTorque(), randTorque(), ForceMode.Impulse );

        gameController = GameObject.Find("GameController").GetComponent<GameController>(); 
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameController.UpdateScore(pointVal);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); 
        Destroy(gameObject);
    } 

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject); 

        if ( !gameObject.CompareTag("Bad") )
        {
            gameController.GameOver(); 
        }

    }

    Vector3 randForce()
    {
        Vector3 retFo = Vector3.up * Random.Range(minSpeed, maxSpeed);
        return retFo; 
    }

    float randTorque()
    {
        float retTo = Random.Range(-maxTorque, maxTorque);
        return retTo; 
    }

    Vector3 randSpawnPos()
    {
        Vector3 retSP = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        return retSP; 
    }
}

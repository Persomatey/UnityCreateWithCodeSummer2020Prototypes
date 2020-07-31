using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explPart;
    public ParticleSystem dirtPart;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio; 

    public float jumpForce;
    public float gravityModifier;
    public bool canSingleJump = true;
    public bool canDoubleJump = false; 
    public bool gameOver;
    private bool didOnce; 

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>(); 
        Physics.gravity *= gravityModifier;

        playerAnim.SetFloat("Speed_f", 0.26f);
        gameOver = true;
    }

    void Update()
    {
        if (transform.position.x < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
        }
        else if ( transform.position.x >= 0 && !didOnce)
        {
            playerAnim.SetFloat("Speed_f", 5.0f);
            gameOver = false;
            didOnce = true; 
        }

        if ( Input.GetKeyDown(KeyCode.Space) && canSingleJump && !canDoubleJump && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canSingleJump = false;
            canDoubleJump = true; 
            dirtPart.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !canSingleJump && canDoubleJump && !gameOver)
        {
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canDoubleJump = false;
            playerAudio.PlayOneShot(jumpSound, 0.8f);
        }

        if( Input.GetKey(KeyCode.B) && !gameOver)
        {
            playerAnim.SetFloat("Speed_Modifier", 2.0f);
        }
        else if ( !Input.GetKey(KeyCode.B) && !gameOver)
        {
            playerAnim.SetFloat("Speed_Modifier", 1.0f);
        }

        if(gameOver)
        {
            dirtPart.Stop();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            canSingleJump = true;
            canDoubleJump = false; 
            dirtPart.Play(); 

        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("<color=red>Game Over!</color>");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explPart.Play();
            dirtPart.Stop();
            playerAudio.PlayOneShot(crashSound, 10.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Obstacle") && !Input.GetKey(KeyCode.B))
        {
            Debug.Log("<color=yellow>Points!</color>");

            GameObject.Find("GameManager").GetComponent<GameManager>().score += 10; 
        }
        else if (col.gameObject.CompareTag("Obstacle") && Input.GetKey(KeyCode.B))
        {
            Debug.Log("<color=green>Bonus Points!</color>");

            GameObject.Find("GameManager").GetComponent<GameManager>().score += 20;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
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

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>(); 
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) && canSingleJump && !canDoubleJump && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canSingleJump = false;
            canDoubleJump = true; 
            dirtPart.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !canSingleJump && canDoubleJump && !gameOver)
        {
            playerRB.velocity = Vector3.zero;
            playerRB.angularVelocity = Vector3.zero;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canDoubleJump = false;
            playerAudio.PlayOneShot(jumpSound, 0.8f);
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
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("<color=green>Point!</color>");

            GameObject.Find("GameManager").GetComponent<GameManager>().score += 10; 
        }
    }
}

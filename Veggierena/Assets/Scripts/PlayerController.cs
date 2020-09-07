using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerModel;

    public GameObject attackNorth;
    public GameObject attackNorthWest;
    public GameObject attackNorthEast;
    public GameObject attackSouth;
    public GameObject attackSouthWest;
    public GameObject attackSouthEast;
    public GameObject attackWest;
    public GameObject attackEast;

    public GameObject partSystem; 

    public GameObject attackStick;

    public GameObject deathScreen1;
    public GameObject deathScreen2;
    public GameObject deathScreen3;
    public GameObject deathScreen4;

    public GameObject doubleDamImage; 

    public int health;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private AudioSource source; 
    public AudioClip hitSFX;
    public AudioClip swingSFX;
    public AudioClip dyingSFX;
    public AudioClip healthPickupSFX;
    public AudioClip atkPickupSFX;

    public float horizInput;
    public float vertInput;
    public float speed = 25;
    public float zRange = 20;
    public float xRange = 2;

    public bool northRes;
    public bool westRes;
    public bool southRes;
    public bool eastRes;

    public bool facingNorth;
    public bool facingWest;
    public bool facingSouth;
    public bool facingEast;

    public bool isAttacking;

    public bool deathState;

    public bool playSFXOnce;

    public int damModifier; 

    void Start()
    {
        doubleDamImage.SetActive(false); 
        source = GetComponent<AudioSource>();
        damModifier = 1; 
    }

    void Update()
    {
        // Health Stuff 
        #region Health Stuff
        if (health <= 0)
        {
            deathState = true;
            
            if (gameObject.transform.localScale.y > 0.075f)
            {
                gameObject.transform.localScale += new Vector3(0, -0.025f, 0);
                if(!playSFXOnce)
                {
                    source.PlayOneShot(dyingSFX, 1.0f);
                    playSFXOnce = true; 
                }
            }
            else if (gameObject.transform.localScale.y <= 0.075f)
            {
                deathScreen1.SetActive(true);
                deathScreen2.SetActive(true);
                deathScreen3.SetActive(true);
                deathScreen4.SetActive(true);
            }
        }
        else if (health > 0)
        {
            deathScreen1.SetActive(false);
            deathScreen2.SetActive(false);
            deathScreen3.SetActive(false);
            deathScreen4.SetActive(false);
        }
        #endregion

        // Movement 
        #region Movement 

        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if (!northRes && !westRes && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !isAttacking && !deathState)         // North West
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = true;
            facingWest = true;
            facingSouth = false;
            facingEast = false;
        }
        else if (!northRes && !eastRes && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !isAttacking && !deathState)    // North East 
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = true;
            facingWest = false;
            facingSouth = false;
            facingEast = true;
        }
        else if (!southRes && !westRes && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !isAttacking && !deathState)    // South West 
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = true;
            facingSouth = true;
            facingEast = false;
        }
        else if (!southRes && !eastRes && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !isAttacking && !deathState)    // South East 
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = false;
            facingSouth = true;
            facingEast = true;
        }
        else if (!northRes && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !isAttacking && !deathState)         // North 
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            facingNorth = true;
            facingWest = false;
            facingSouth = false;
            facingEast = false; 
        }
        else if (!southRes && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !isAttacking && !deathState)         // South 
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = false;
            facingSouth = true;
            facingEast = false;
        }
        else if (!westRes && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !isAttacking && !deathState)         // West 
        {
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = true;
            facingSouth = false;
            facingEast = false;
        }
        else if (!eastRes && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !isAttacking && !deathState)         // East 
        {
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = false;
            facingSouth = false;
            facingEast = true;
        }

        #endregion

        // Rotation 
        #region Rotation 

        if (facingNorth && !facingSouth && !facingWest && !facingEast && !deathState)       // North 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        else if (facingNorth && !facingSouth && !facingWest && facingEast && !deathState)   // North East 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 45, transform.eulerAngles.z);
        }
        else if (!facingNorth && !facingSouth && !facingWest && facingEast && !deathState)  // East 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && !facingWest && facingEast && !deathState)   // South East
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 135, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && !facingWest && !facingEast && !deathState)  // South 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && facingWest && !facingEast && !deathState)   // South West 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 225, transform.eulerAngles.z);
        }
        else if (!facingNorth && !facingSouth && facingWest && !facingEast && !deathState)  // West 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);
        }
        else if (facingNorth && !facingSouth && facingWest && !facingEast && !deathState)   // North West 
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 315, transform.eulerAngles.z);
        }

        #endregion

        // Attack 
        #region Attack

        if ( Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            source.PlayOneShot(swingSFX, 1.0f); 
            isAttacking = true; 
            Invoke("AllowPlayer", 0.1f);

            if (facingNorth && !facingSouth && !facingWest && !facingEast && !deathState)   // North
            {
                Instantiate(attackStick, 
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 0.6f),
                    new Quaternion( 
                        attackNorth.GetComponent<Transform>().rotation.x, 
                        -1, 
                        attackNorth.GetComponent<Transform>().rotation.z, 
                        attackNorth.GetComponent<Transform>().rotation.w)); 
                attackNorth.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (facingNorth && !facingSouth && !facingWest && facingEast && !deathState)   // North East
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x + 0.4f,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 0.8f),
                    attackNorthEast.GetComponent<Transform>().rotation);
                attackNorthEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && !facingSouth && !facingWest && facingEast && !deathState)  // East 
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x + 0.5f,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 1),
                    new Quaternion(
                        attackNorth.GetComponent<Transform>().rotation.x,
                        0,
                        attackNorth.GetComponent<Transform>().rotation.z,
                        attackNorth.GetComponent<Transform>().rotation.w));
                attackEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && !facingWest && facingEast && !deathState)   // South East 
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x + 0.4f,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 1.4f),
                    attackSouthEast.GetComponent<Transform>().rotation);
                attackSouthEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && !facingWest && !facingEast && !deathState)  // South 
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 1.6f),
                    new Quaternion(
                        attackNorth.GetComponent<Transform>().rotation.x,
                        1,
                        attackNorth.GetComponent<Transform>().rotation.z,
                        attackNorth.GetComponent<Transform>().rotation.w));
                attackSouth.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && facingWest && !facingEast && !deathState)   // South West 
            {
                Instantiate(attackStick,
                       new Vector3(
                           attackNorth.GetComponent<Transform>().position.x - 0.4f,
                           attackNorth.GetComponent<Transform>().position.y,
                           attackNorth.GetComponent<Transform>().position.z - 1.4f),
                       attackSouthWest.GetComponent<Transform>().rotation);
                attackSouthWest.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && !facingSouth && facingWest && !facingEast && !deathState)  // West 
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x - 0.5f,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 1),
                    new Quaternion(
                        attackNorth.GetComponent<Transform>().rotation.x,
                        1,
                        attackNorth.GetComponent<Transform>().rotation.z,
                        0));
                attackWest.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (facingNorth && !facingSouth && facingWest && !facingEast && !deathState)   // North West
            {
                Instantiate(attackStick,
                    new Vector3(
                        attackNorth.GetComponent<Transform>().position.x - 0.4f,
                        attackNorth.GetComponent<Transform>().position.y,
                        attackNorth.GetComponent<Transform>().position.z - 0.8f),
                    attackNorthWest.GetComponent<Transform>().rotation);
                attackNorthWest.GetComponent<DamageEnemy>().ActivateBool();
            }
        }

        #endregion

        // Constraints
        #region Constraints

        RaycastHit northHit;
        Vector3 north = transform.TransformDirection(Vector3.forward);
        if ( Physics.Raycast(transform.position, north, out northHit, 0.75f) && ( northHit.collider.gameObject.tag == "Wall" || northHit.collider.gameObject.tag == "Enemy") )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.75f, Color.red);
            northRes = true; 
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.75f, Color.white);
            northRes = false; 
        }

        RaycastHit southHit;
        Vector3 south = transform.TransformDirection(-Vector3.forward);
        if (Physics.Raycast(transform.position, south, out southHit, 0.75f) && ( southHit.collider.gameObject.tag == "Wall" || southHit.collider.gameObject.tag == "Enemy") )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 0.75f, Color.red);
            southRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 0.75f, Color.white);
            southRes = false;
        }

        RaycastHit westHit;
        Vector3 west = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, west, out westHit, 0.75f) && ( westHit.collider.gameObject.tag == "Wall" || westHit.collider.gameObject.tag == "Enemy") )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.75f, Color.red);
            westRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.75f, Color.white);
            westRes = false;
        }

        RaycastHit eastHit;
        Vector3 east = transform.TransformDirection(-Vector3.left);
        if (Physics.Raycast(transform.position, east, out eastHit, 0.75f) && ( eastHit.collider.gameObject.tag == "Wall" || eastHit.collider.gameObject.tag == "Enemy" ) )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.75f, Color.red);
            eastRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.75f, Color.white);
            eastRes = false;
        }

        #endregion

        // Health Display 
        #region Health Display
        if ( health == 3 )
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        #endregion
    }

    void AllowPlayer()
    {
        isAttacking = false;
    }

    public void HurtHealth(int dam)
    {
        health -= dam;
        source.PlayOneShot(hitSFX, 1.0f);
        partSystem.SetActive(true);
        Invoke("DeactivatePart", 0.25f); 
    }

    void DeactivatePart()
    {
        partSystem.SetActive(false);
    }

    public void HealHealth(int add)
    {
        source.PlayOneShot(healthPickupSFX, 1.0f);
        if (health < 3)
        {
            health += add;
        } 
    }

    public void PushPlayer(Vector3 direction)
    {
        //StartCoroutine(Please(direction));
        GetComponent<Rigidbody>().AddForce(direction * 750);
        Invoke("StopVelocity", 0.2f); 
    }

    public void StopVelocity()
    {
        Debug.Log("Stopping Velocity"); 
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void RaiseDamModifier()
    {
        damModifier = 2;
        doubleDamImage.SetActive(true); 
        Invoke("ResetModifier", 10.0f);
        source.PlayOneShot(atkPickupSFX, 1.0f);
    }

    void ResetModifier()
    {
        damModifier = 1;
        doubleDamImage.SetActive(false);
    }
}

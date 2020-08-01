using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerModel;
    public GameObject hitBox;

    public GameObject attackNorth;
    public GameObject attackNorthWest;
    public GameObject attackNorthEast;
    public GameObject attackSouth;
    public GameObject attackSouthWest;
    public GameObject attackSouthEast;
    public GameObject attackWest;
    public GameObject attackEast;

    public int health = 5; 

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

    void Update()
    {
        // Death State 
        if(health <= 0)
        {
            deathState = true; 
        }

        // Movement 
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if (vertInput > 0 && horizInput < 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * (speed / 2) );
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * (speed / 2) );
            facingNorth = true;
            facingWest = true;
            facingSouth = false;
            facingEast = false;
        }
        else if (vertInput > 0 && horizInput > 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * (speed / 2));
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * (speed / 2));
            facingNorth = true;
            facingWest = false;
            facingSouth = false;
            facingEast = true;
        }
        else if (vertInput < 0 && horizInput < 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * (speed / 2));
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * (speed / 2));
            facingNorth = false;
            facingWest = true;
            facingSouth = true;
            facingEast = false;
        }
        else if (vertInput < 0 && horizInput > 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * (speed / 2));
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * (speed / 2));
            facingNorth = false;
            facingWest = false;
            facingSouth = true;
            facingEast = true;
        }
        else if (!northRes && vertInput > 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            facingNorth = true;
            facingWest = false;
            facingSouth = false;
            facingEast = false; 
        }
        else if (!southRes && vertInput < 0 && !isAttacking && !deathState)
        {
            transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = false;
            facingSouth = true;
            facingEast = false;
        }
        else if (!westRes && horizInput < 0 && !isAttacking && !deathState)
        {
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = true;
            facingSouth = false;
            facingEast = false;
        }
        else if (!eastRes && horizInput > 0 && !isAttacking && !deathState)
        {
            transform.Translate(-Vector3.left * horizInput * Time.deltaTime * speed);
            facingNorth = false;
            facingWest = false;
            facingSouth = false;
            facingEast = true;
        }

        // Rotation 
        if(facingNorth && !facingSouth && !facingWest && !facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3( transform.eulerAngles.x, 0, transform.eulerAngles.z );
        }
        else if (facingNorth && !facingSouth && !facingWest && facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 45, transform.eulerAngles.z);
        }
        else if (!facingNorth && !facingSouth && !facingWest && facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && !facingWest && facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 135, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && !facingWest && !facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        else if (!facingNorth && facingSouth && facingWest && !facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 225, transform.eulerAngles.z);
        }
        else if (!facingNorth && !facingSouth && facingWest && !facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);
        }
        else if (facingNorth && !facingSouth && facingWest && !facingEast && !deathState)
        {
            playerModel.eulerAngles = new Vector3(transform.eulerAngles.x, 315, transform.eulerAngles.z);
        }

        // Attack 
        if( Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            Vector3 attackLoc;
            isAttacking = true; 
            Invoke("AllowPlayer", 0.1f);

            if (facingNorth && !facingSouth && !facingWest && !facingEast && !deathState)
            {
                attackNorth.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (facingNorth && !facingSouth && !facingWest && facingEast && !deathState)
            {
                attackNorthEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && !facingSouth && !facingWest && facingEast && !deathState)
            {
                attackEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && !facingWest && facingEast && !deathState)
            {
                attackSouthEast.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && !facingWest && !facingEast && !deathState)
            {
                attackSouth.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && facingSouth && facingWest && !facingEast && !deathState)
            {
                attackSouthWest.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (!facingNorth && !facingSouth && facingWest && !facingEast && !deathState)
            {
                attackWest.GetComponent<DamageEnemy>().ActivateBool();
            }
            else if (facingNorth && !facingSouth && facingWest && !facingEast && !deathState)
            {
                attackNorthWest.GetComponent<DamageEnemy>().ActivateBool();
            }
        }

        // Constraint (North) 
        RaycastHit northHit;
        Vector3 north = transform.TransformDirection(Vector3.forward);
        if ( Physics.Raycast(transform.position, north, out northHit, 0.5f) && northHit.collider.gameObject.tag == "Wall" )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.5f, Color.red);
            northRes = true; 
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.5f, Color.white);
            northRes = false; 
        }

        // Constraint (South)
        RaycastHit southHit;
        Vector3 south = transform.TransformDirection(-Vector3.forward);
        if (Physics.Raycast(transform.position, south, out southHit, 0.5f) && southHit.collider.gameObject.tag == "Wall")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 0.5f, Color.red);
            southRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 0.5f, Color.white);
            southRes = false;
        }

        // Constraint (West) 
        RaycastHit westHit;
        Vector3 west = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, west, out westHit, 0.5f) && westHit.collider.gameObject.tag == "Wall")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.red);
            westRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.white);
            westRes = false;
        }

        // Constraint (East) 
        RaycastHit eastHit;
        Vector3 east = transform.TransformDirection(-Vector3.left);
        if (Physics.Raycast(transform.position, east, out eastHit, 0.5f) && eastHit.collider.gameObject.tag == "Wall")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.5f, Color.red);
            eastRes = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.5f, Color.white);
            eastRes = false;
        }
    }

    void AllowPlayer()
    {
        isAttacking = false;
    }

    public void HurtHealth(int dam)
    {
        health -= dam; 
    }
}

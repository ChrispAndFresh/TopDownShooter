using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

/*
 * Chris Pimentel 
 * 11/13/25
 * Contols movement and other elements of the player
 */

public class PlayerController : MonoBehaviour
{
    private Vector3 direction; //Controls direction of player
    public float speed; //Controls player speed
    public Rigidbody rb; //Reference to player's rigidbody for movement

    public GameObject gunSlot; //Reference to the gun slot that holds the gun
    public GunBase heldGun; //Reference to the currently held gun
    public PlayerInventory inventory;//Reference to player's inventory

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        RotatePlayer();
        
    }

 

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Allows the player to move in 4 directions on the xy-plane
    /// </summary>
    private void Move()
    {
        //Determines the player's movement on the x-axis
        LeftAndRight();
        //Determines the player's movement on the y-axis
        UpAndDown();

        //Moves the player using the direction given from LeftAndRight() and UpAndDown()
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime); 

    }


    /// <summary>
    /// Determines player's movement of x-axis
    /// </summary>
   private void LeftAndRight()
    {
        //If player is moving left and not right
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            direction.x = -1;
        }
        //If player is moving right and not left
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            direction.x = 1;
        }
        //If no buttons are pressed
        else
        {
            direction.x = 0;
        }
    }


    //Determines the player's movement on the y-axis
    private void UpAndDown()
    {
        //If player is moving up and not down
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            direction.y = 1;
        }
        //If player is moving down and not up
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            direction.y = -1;
        }
        //If no buttons are pressed
        else
        {
            direction.y = 0;
        }
    }


    /// <summary>
    /// Rotates the player to always be facing the mouse
    /// </summary>
    private void RotatePlayer()
    {
        //Get the mouse's position on the screen, bottom left corner as 0,0
        Vector3 mouseScreenPos = Input.mousePosition;
        //print("Mouse Screen Position: " + mouseScreenPos);
        //Set position with positive z-depth 
        //No idea what this does but it makes everything work
        mouseScreenPos.z = 10; 

        //Converts screen position to world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        //print("Mouse World Position: " + mouseWorldPos);

        Vector3 directionToMouse = mouseWorldPos - transform.position;
        //print("Vector from player to mouse: " +  directionToMouse);


        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        //print("Angle of player to mouse: " + angle);

        //Checks if mouse is not directly over player
        if (directionToMouse != Vector3.zero)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, angle);
        }
    }


    
}

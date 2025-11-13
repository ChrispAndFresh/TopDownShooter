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
    private Rigidbody rb; //Reference to player's rigidbody for movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
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
}

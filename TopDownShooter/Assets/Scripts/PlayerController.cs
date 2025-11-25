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

    public Transform gunSlot; //Reference to gun slot for animation purposes

    public UI_Display healthOnUI; //Reference to UI to update heatlh
    public int health; //Health of the player
    public int maxHealth; //Maximum health of the player

    public static Vector3 playerPos; //Refernce to the player's position for enemies

    public GameObject knightSprite; //Used to flip the sprite to stay consistant

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthOnUI.UpdateHealthOnUI(health);
        knightSprite.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    { 
        RotatePlayer();
        playerPos = transform.position;

        rb.velocity = Vector3.zero;
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


        //If player is rotated between 90 and 180 degrees, flip gun and knight
        if (transform.localEulerAngles.z <= 270 && transform.localEulerAngles.z >= 90)
        {
            gunSlot.localEulerAngles = new Vector3(180f, 0f, 0f);
            knightSprite.transform.localEulerAngles = new Vector3(0f, 0f, -angle);
        }
        //If player is rotated between 90 and -90 degrees, unfip gun and knight
        else
        {
            gunSlot.localEulerAngles = new Vector3(0f, 0f, 0f);
            knightSprite.transform.localEulerAngles = new Vector3(0f, 180f, angle);
        }
    }


    /// <summary>
    /// When the player gets damaged, subtract damage from health
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamaged(int damage)
    {
        health -= damage;
        healthOnUI.UpdateHealthOnUI(health);
    }


    /// <summary>
    /// Healing 
    /// </summary>
    /// <param name="healing"></param>
    public void GetHealed(int healing)
    {
        health += healing;

        //Caps health at maxHealth
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthOnUI.UpdateHealthOnUI(health);
    }


    /// <summary>
    /// Increases the max HP of the player
    /// </summary>
    public void IncreaseHealth()
    {
        maxHealth += 2;
        health = maxHealth;
        healthOnUI.UpdateHealthOnUI(health);
    }


}

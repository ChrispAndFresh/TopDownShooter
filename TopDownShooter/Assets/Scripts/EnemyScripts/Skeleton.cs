using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/19/25
 * Handles behavior of skeleton enemy
 */

public class Skeleton : Enemy
{
    bool canMove; //Controls if the skeleton can move or not
    Vector3 direction; //Controls which direction the skeleton is moving
    Rigidbody rb; //Reference to enemy's rigidbody for movement

    public GameObject bonePrefab; //Reference to the projectile the skeleton throws
    public float pauseTime; //How long the skeleton pauses before throwing projectile and moving again

    public float directionDelay; //Determines how long til skeleton changes direction
    public float projectileDelay; //Determines how long til skeleton throws a projectile

    void Awake()
    {
        //Set position, health, and isActive
        SetStartingValues();

        //Changes skeleton's direction every 1 second
        InvokeRepeating("ChangeDirections", 0, 1);

        //Skeleton throws projectiles 
        InvokeRepeating("ThrowBone", 1, projectileDelay);

        canMove = true; //Skeleton can move at the start

        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Activation();
    }

    private void FixedUpdate()
    {
        //Checks if the skeleton has been activated and can move
        if (isActive && canMove)
        {
            //Moves the skeleton in the direction specified by ChangeDirections()
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Picks a random direction to move on an xy-plane
    /// </summary>
    void ChangeDirections()
    {
        //Picks a radnom number 0-3
        int directionChoice = Random.Range(0, 4);

        //Picks a direction based off the random number
        switch (directionChoice) 
        {
            case 0: 
                direction = Vector3.up;
                break;
            case 1:
                direction = Vector3.down;
                break;
            case 2:
                direction = Vector3.left;
                break;
            case 3:
                direction = Vector3.right;
                break;
        }
    }


    /// <summary>
    /// Starts the coroutine to throw bone
    /// </summary>
    void ThrowBone()
    {
        //Only throw bones if active
        if (isActive)
        {
            //Cant start a coroutine in a InvokeRepeating I guess
            StartCoroutine(Bone());
        }
    }
    

    /// <summary>
    /// Creates a projectile that will go towards the player
    /// </summary>
    IEnumerator Bone()
    {
        //If skeleton is active, throw projectile
        if (isActive)
        {
            //Skeleton stops moving
            canMove = false;

            //Skeleton pauses 
            yield return new WaitForSeconds(pauseTime);

            //Skeleton throws projectile
            Instantiate(bonePrefab, transform.position, transform.rotation);

            //Skeleton can move again
            canMove = true;
        }
        //If skeleton is inactive, do nothing
        else
        {
            yield return new WaitForSeconds(0f);
        }

    }
}

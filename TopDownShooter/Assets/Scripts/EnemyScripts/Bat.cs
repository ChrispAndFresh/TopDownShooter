using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/18/25
 * Handles behavior of bat enemies
 */

public class Bat : Enemy
{
    public bool isChasing;
    Rigidbody rb;
    Vector3 moveDirection;

    void Awake()
    {
        //Set position, health, and isActive
        SetStartingValues();
        //Bat doesn't start out chasing
        isChasing = false;
        //Get rigidbody reference for movement
        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }

    private void Update()
    {
        PickDirectionToMove();
    }

    private void FixedUpdate()
    {
        //Moves the enemy to the player
        if (isActive)
        {
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
    }


    /// <summary>
    /// Moves the bat to the player's location
    /// </summary>
    void MoveToPlayer()
    {
        //Moves the bat left 
        if (transform.position.x > PlayerController.playerPos.x)
        {
            rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
        }
        //Moves the bat right
        else if (transform.position.x < PlayerController.playerPos.x)
        {
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
        }

        //Moves the bat down
        if (transform.position.y > PlayerController.playerPos.y)
        {
            rb.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);
        }
        //Moves the bat up
        else if (transform.position.y < PlayerController.playerPos.y)
        {
            rb.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);
        }
    }

    
    /// <summary>
    /// Sets if the bat will chase the player
    /// </summary>
    /// <param name="willChase"></param>
    public void SetChasing(bool willChase)
    {
        isChasing = willChase;
    }


    void PickDirectionToMove()
    {
        //Moves the bat left 
        if (transform.position.x > PlayerController.playerPos.x)
        {
            moveDirection.x = -1;
        }
        //Moves the bat right
        else if (transform.position.x < PlayerController.playerPos.x)
        {
            moveDirection.x = 1;
        }
        else
        {
            moveDirection.x = 0;
        }

        //Moves the bat down
        if (transform.position.y > PlayerController.playerPos.y)
        {
            moveDirection.y = -1;
        }
        //Moves the bat up
        else if (transform.position.y < PlayerController.playerPos.y)
        {
            moveDirection.y = 1;
        }
        else
        {
            moveDirection.y = 0;
        }
    }

    /// <summary>
    /// When resetting the bat, isChasing will no longer be true
    /// </summary>
    public override void ResetEnemy()
    {
        base.ResetEnemy();
        isChasing = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Chris Pimentel
 * 11/20/25
 * Handles behavior of the darknut enemy
 */

public enum Direction 
{ 
    Up,
    Down,
    Left, 
    Right,
}


public class Darknut : Enemy
{
    //Finds the angle between the player and enemy
    private float angleBetweenPlayerAndEnemy; 
    
    private Direction enemyDirection; //Which direction the enemy is facing
    private bool canMove; //Determines is the enemy can turn or not
    public float turnCooldown; //How long it takes before the enemy can turn again (in seconds)

    Rigidbody rb; //Reference to rigidbody for movement
    private Vector3 moveDirection; //Determines which direction the enemy will move in

    private void Awake()
    {
        //Set position, health, and isActive
        SetStartingValues();

        //Starting direction is down
        enemyDirection = Direction.Down;

        //Enemy starts out being able to turn
        canMove = true;

        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }


    private void Update()
    {
        Activation();

        //Gets the vector between player and enemy
        Vector3 directionToPlayer = PlayerController.playerPos - transform.position;

        //Gets the angle between player and enemy
        angleBetweenPlayerAndEnemy = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        //Checks if enemy is active and can turn
        if (isActive && canMove)
        {
            //Checks angle between player and enemy and turns the enemy to face the correct direction
            ShouldTheEnemyTurn();
        }

        //Finds the direction the enemy should move
        PickDirectionToMove();
    }

    private void FixedUpdate()
    {
        //Moves the enemy to the player
        if (isActive && canMove)
        {
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
    }

    void ShouldTheEnemyTurn()
    {
        //If the enemy is facing down
        if (enemyDirection == Direction.Down)
        {
            //If the player is to the left 
            if ((angleBetweenPlayerAndEnemy < -135 && angleBetweenPlayerAndEnemy >= -180) || (angleBetweenPlayerAndEnemy > 90 && angleBetweenPlayerAndEnemy <= 180))
            {
                StartCoroutine(FaceLeft());
            }
            //If the player is to the right
            else if (angleBetweenPlayerAndEnemy <= 90 && angleBetweenPlayerAndEnemy > -45)
            {
                StartCoroutine(FaceRight());
            }
        }

        //If the enemy is facing left
        if (enemyDirection == Direction.Left)
        {
            //If the player is below
            if (angleBetweenPlayerAndEnemy <= 0 && angleBetweenPlayerAndEnemy > -135)
            {
                StartCoroutine(FaceDown());
            }
            //If the player is above
            else if (angleBetweenPlayerAndEnemy < 135 && angleBetweenPlayerAndEnemy > 0)
            {
                StartCoroutine(FaceUp());
            }
        }

        //If the enemy is facing right
        if (enemyDirection == Direction.Right)
        {
            //If the player is below
            if (angleBetweenPlayerAndEnemy < -45 && angleBetweenPlayerAndEnemy >= -180)
            {
                StartCoroutine(FaceDown());
            }
            //If the player is above
            else if (angleBetweenPlayerAndEnemy <= 180 && angleBetweenPlayerAndEnemy > 45)
            {
                StartCoroutine(FaceUp());
            }
        }

        //If the enemy is facing up
        if (enemyDirection == Direction.Up)
        {
            //If the player is to the left 
            if ((angleBetweenPlayerAndEnemy > 135 && angleBetweenPlayerAndEnemy <= 180) || (angleBetweenPlayerAndEnemy <= -90 && angleBetweenPlayerAndEnemy >= -180))
            {
                StartCoroutine(FaceLeft());
            }
            //If the player is to the right
            else if (angleBetweenPlayerAndEnemy < 45 && angleBetweenPlayerAndEnemy > -90)
            {
                StartCoroutine(FaceRight());
            }
        }

    }


    //Rotates the enemy to face left
    public IEnumerator FaceLeft()
    {
        //Enemy can no longer turn
        canMove = false;

        //Stall the enemy for turnCooldown seconds
        yield return new WaitForSeconds(turnCooldown);

        //Set rotation
        transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        //Set direction
        enemyDirection = Direction.Left;
        //Enemy can turn again
        canMove = true;
    }

    //Rotates the enemy to face right
    public IEnumerator FaceRight()
    {
        //Enemy can no longer turn
        canMove = false;

        //Stall the enemy for turnCooldown seconds
        yield return new WaitForSeconds(turnCooldown);

        //Set rotation
        transform.localEulerAngles = new Vector3(0f, 0f, 90f);
        //Set direction
        enemyDirection = Direction.Right;
        //Enemy can turn again
        canMove = true;
    }

    //Rotates the enemy to face up
    public IEnumerator FaceUp()
    {
        //Enemy can no longer turn
        canMove = false;

        //Stall the enemy for turnCooldown seconds
        yield return new WaitForSeconds(turnCooldown);

        //Set rotation
        transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        //Set direction
        enemyDirection = Direction.Up;
        //Enemy can turn again
        canMove = true;
    }

    //Rotates the enemy to face down
    public IEnumerator FaceDown()
    {
        //Enemy can no longer turn
        canMove = false;

        //Stall the enemy for turnCooldown seconds
        yield return new WaitForSeconds(turnCooldown);

        //Set rotation
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        //Set direction
        enemyDirection = Direction.Down;
        //Enemy can turn again
        canMove = true;
    }


    //Move the enemy to the player location
    void PickDirectionToMove()
    {
        //Moves the darknut left 
        if (transform.position.x > PlayerController.playerPos.x)
        {
            moveDirection.x = -1;
        }
        //Moves the darknut right
        else if (transform.position.x < PlayerController.playerPos.x)
        {
            moveDirection.x = 1;
        }
        else
        {
            moveDirection.x = 0;
        }

        //Moves the darknut down
        if (transform.position.y > PlayerController.playerPos.y)
        {
            moveDirection.y = -1;
        }
        //Moves the darknut up
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
    /// When resetting the darknut, reset turning as well
    /// </summary>
    public override void ResetEnemy()
    {
        base.ResetEnemy();
        enemyDirection = Direction.Down;
        canMove = true;
    }
}

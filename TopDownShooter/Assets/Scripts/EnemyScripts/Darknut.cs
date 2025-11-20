using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/20/25
 * Handles behavior of the darknut enemy
 */

public class Darknut : Enemy
{
    //Finds the angle between the player and enemy
    private float angleBetweenPlayerAndEnemy; 

    private void Awake()
    {
        SetStartingValues();
    }


    private void Update()
    {
        //Gets the vector between player and enemy
        Vector3 directionToPlayer = PlayerController.playerPos - transform.position;

        //Gets the angle between player and enemy
        angleBetweenPlayerAndEnemy = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        if(Input.GetKeyDown(KeyCode.G))
        {
            print("Angle between player and enemy: " + angleBetweenPlayerAndEnemy);
            print("Darknut Rotation: " + transform.rotation.z);
        }

        //Checks if the enemy should turn to face the player
        ShouldTheEnemyTurn();
    }


    /// <summary>
    /// Checks if the enemy should turn to face the player
    /// </summary>
    void ShouldTheEnemyTurn()
    {
        //If the darknut is facing down
        if (transform.rotation.z == 0)
        {
            //If the player is to the left
            if (angleBetweenPlayerAndEnemy < -135 || angleBetweenPlayerAndEnemy >= 90)
            {
                TurnRight();
            }
            //If the player is to the right
            else if (angleBetweenPlayerAndEnemy > -45 || angleBetweenPlayerAndEnemy <= 90)
            {
                TurnLeft();
            }
        }
        
        //If the darknut is facing right
        if (transform.rotation.z == 90)
        {
            //If the player is above
            if(angleBetweenPlayerAndEnemy > 45)
            {
                TurnLeft();
            }
            //If the player is below
            else if (angleBetweenPlayerAndEnemy < -45)
            {
                TurnRight();
            }
        }

        //If the darknut is facing up
        if (transform.rotation.z == -180)
        {
            //If the player is to the right
            if (angleBetweenPlayerAndEnemy < 45 || angleBetweenPlayerAndEnemy >= -90)
            {
                TurnRight();
            }
            //If the player is to the left 
            else if (angleBetweenPlayerAndEnemy > 135 || angleBetweenPlayerAndEnemy <= -90)
            {
                TurnLeft();
            }
        }

        //If the darknut is facing left
        if (transform.rotation.z == -90)
        {
            //If the player is above
            if (angleBetweenPlayerAndEnemy < 135)
            {
                TurnRight();
            }
            //If the player is below
            else if (angleBetweenPlayerAndEnemy > -135)
            {
                TurnLeft();
            }
        }

    }


    /// <summary>
    /// Turns the enemy right
    /// </summary>
    void TurnRight()
    {
    
    }


    /// <summary>
    /// Turns the enemy right
    /// </summary>
    void TurnLeft()
    {
        
    }

}

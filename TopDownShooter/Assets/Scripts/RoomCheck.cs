using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/17/25
 * Handles room checks for enemies and player
 * Allows for respawning and resetting of enemies
 */

public class RoomCheck : MonoBehaviour
{
    public bool hasEnemies;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<PlayerController>())
        {
            //print("enemy in room");
            hasEnemies = true;
        }

        if (!other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<PlayerController>())
        {
            hasEnemies = false;
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
       //Checks if the player has left the room
       if (other.gameObject.GetComponent<PlayerController>())
        {
            if (hasEnemies)
            {
                print("Resetting enemies in room");
            }
            else
            {
                print("Respawning enemies in room");
            }


        }
    }
}

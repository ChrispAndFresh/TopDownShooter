using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/2/25
 * Allows for spawning of items when a room is cleared of enemies
 */

public class RoomManager : MonoBehaviour
{ 
    //Spawns an item when no enemies are left if the room
    public void SpawnItem()
    {
        //Gets the list of enemis for each room
        List<Enemy> enemiesInRoom = GetComponent<RoomCheck>().enemiesInRoom;
        int disabledEnemies = 0;

        //Cycles through the list
        for (int i = 0; i < enemiesInRoom.Count; i++)
        {
            //Checks if the enemy is disabled
            if (!enemiesInRoom[i].gameObject.activeSelf)
            {
                disabledEnemies++; //Increases counter
            }
        }


        //If all the enemies in the list are disabled, spawn an item
        if (disabledEnemies == enemiesInRoom.Count)
        {
            GetComponent<RoomCheck>().SpawnItem();
        }

    }


}
   

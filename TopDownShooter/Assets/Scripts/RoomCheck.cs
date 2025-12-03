using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/17/25
 * Handles room checks for enemies and player
 * Allows for respawning and resetting of enemies
 */

public class RoomCheck : MonoBehaviour
{
    public List<Enemy> enemiesInRoom; //List of the current enemies in the room

    public List<Enemy> respawnEnemies; //Enemies that will populate the room when the room is clear
    public List<Transform> spawnPoints; //Spawn points of new enemies

    public GameObject roomDrop; //What the room will drop when all enemies are defeated


    private void Start()
    {
        //Assigns each enemy in the room with the respective RoomManager
        for (int i = 0; i < enemiesInRoom.Count; i++)
        {
            enemiesInRoom[i].roomManager = GetComponent<RoomManager>();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //Checks if the player is leaving the room
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //CountEnemies();

            //Cycles through the list of enemies
            for (int i = 0; i < enemiesInRoom.Count; i++)
            {
                //Checks if the enemy is disabled
                if (!enemiesInRoom[i].gameObject.activeSelf)
                {
                    //Destroys the enemy gameObject
                    Destroy(enemiesInRoom[i].gameObject);
                    //Removes the enemy from the list
                    enemiesInRoom.RemoveAt(i);
                    //Makes it so counter doesn't skip any enemies in the list
                    i--;
                }
            }


            //If there are still enemies, reset position and health
            if (enemiesInRoom.Count  > 0)
            {
                //print("Reset Enemies");
                for (int i = 0; i < enemiesInRoom.Count; i++)
                {
                    enemiesInRoom[i].ResetEnemy();
                }
            }
            //If there are no enemies, spawn new ones
            else
            {
                print("Respawn Enemies");
                for (int i = 0; i < respawnEnemies.Count; i++)
                {
                    enemiesInRoom.Add(Instantiate(respawnEnemies[i], spawnPoints[i].position, spawnPoints[i].rotation));
                }
            }
        }
    }


    public void AddEnemy(Enemy newEnemy, Transform spawnPoint)
    {
        enemiesInRoom.Add(Instantiate(newEnemy, spawnPoint.position, spawnPoint.rotation));
    }

    //Spawns an item when called
    public void SpawnItem()
    {
        if (roomDrop != null)
        {
            Instantiate(roomDrop, transform.position, transform.rotation);
        }
    }


}

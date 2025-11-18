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
    public List<Enemy> enemiesInRoom;

    public List<Enemy> respawnEnemies;
    public List<Transform> spawnPoints;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            CountEnemies();

            for (int i = 0; i < enemiesInRoom.Count; i++)
            {
                if (!enemiesInRoom[i].gameObject.activeSelf)
                {
                    Destroy(enemiesInRoom[i].gameObject);
                    enemiesInRoom.RemoveAt(i);
                    i--;
                }
            }


            if (enemiesInRoom.Count  > 0)
            {
                //print("Reset Enemies");
                for (int i = 0; i < enemiesInRoom.Count; i++)
                {
                    enemiesInRoom[i].ResetEnemy();
                }
            }
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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("Enemies in room: " + enemiesInRoom.Count);
        }
    }

    private void CountEnemies()
    {

        int enabledEnemies = 0;
        int disabledEnemies = 0;

        for (int i = 0; i < enemiesInRoom.Count; i++)
        {
            if (enemiesInRoom[i].gameObject.activeSelf)
            {
                enabledEnemies++;
            }
            else
            {
                disabledEnemies++;
            }
        }

        print("Active Enemies: " + enabledEnemies + " | Inactive Enemies: " + disabledEnemies);

    }
}

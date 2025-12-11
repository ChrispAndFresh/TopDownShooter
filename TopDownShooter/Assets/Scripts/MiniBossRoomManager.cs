using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/9/25
 * Handles all of the things that happen in the miniboss room
 */

public class MiniBossRoomManager : MonoBehaviour
{
    public List<GameObject> walls; //List of walls to block the player from leaving the room
    public FrogShadow miniboss; //The miniboss that gets spawned

    //Items that get spawned upon the miniboss's death
    public GameObject key;
    public GameObject healthIncrease;

    private void Start()
    {
        //The walls start out inactive as the player is allowed to enter and exit the room freely
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].SetActive(false);
        }
    }

    /// <summary>
    /// When triggered, spawn the miniboss and activate the walls so the player cannot leave
    /// </summary>
    public void SpawnMiniBoss()
    {
        if (miniboss != null)
        {
            //Creates the miniboss
            miniboss = Instantiate(miniboss, transform.position, transform.rotation);
            miniboss.room = GetComponent<MiniBossRoomManager>();
            miniboss.PassRoomToFrog(GetComponent<RoomManager>());

            //Activates the walls
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].SetActive(true);
            }

            //Once miniboss has been spawned, it can no longer be spawned.
            miniboss = null;
        }
    }


    /// <summary>
    /// Deactivates the walls so the player can leave
    /// </summary>
    public void RemoveWalls()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].SetActive(false);
        }
    }


    /// <summary>
    /// Spawns a key and health increase when called
    /// </summary>
    public void SpawnItems()
    {
        //Checks if there is a key to spawn
        if (key != null) 
        {
            //Creates the key
            Instantiate(key, transform.position + new Vector3 (1f, 0f, 0f), transform.rotation);
            //Key can only be spawned once
            key = null;
        }

        //Checks if there is a health increase to spawn
        if (healthIncrease != null)
        {
            //Creates the healthIncrease
            Instantiate(healthIncrease, transform.position + new Vector3(-1f, 0f, 0f), transform.rotation);
            //HealthIncrease can only be spawned once
            healthIncrease = null;
        }

    }
}

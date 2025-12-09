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
        //Creates the miniboss
        miniboss = Instantiate(miniboss, transform.position, transform.rotation);
        miniboss.room = GetComponent<MiniBossRoomManager>();

        //Activates the walls
        for (int i = 0;i < walls.Count;i++)
        {
            walls[i].SetActive(true);
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

}

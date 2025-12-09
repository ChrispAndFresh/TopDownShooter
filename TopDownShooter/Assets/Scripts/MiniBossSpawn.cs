using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/2/25
 * Spawn the miniboss when player has picked up the shotgun
 */

public class MiniBossSpawn : MonoBehaviour
{
    public MiniBossRoomManager minibossRoom; //Reference to roombox of miniboss room

    private void OnTriggerExit(Collider other)
    {
        //Checks if what is leaving is the player
        if (other.gameObject.GetComponent<PlayerInventory>())
        {
            minibossRoom.SpawnMiniBoss();
        }
    }
}

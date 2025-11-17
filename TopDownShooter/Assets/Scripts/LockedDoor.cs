using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/16/25
 * Handles functioning of locked doors
 */

public class LockedDoor : MonoBehaviour
{
    public Door door; //Reference to the door that this lock goes to

    private void Start()
    {
        //Player cannot use door until unlocked
        StartCoroutine(LockDoor());
    }

    private void OnTriggerStay(Collider other)
    {
        //Checks if what is colliding is the player
        if (other.gameObject.GetComponent<PlayerInventory>())
        {
            //If the player has keys and interacts with the door
            if (other.gameObject.GetComponent<PlayerInventory>().HasKey() && other.GetComponent<PlayerInventory>().interacting)
            {
                //Removes a key from player inventory
                other.gameObject.GetComponent<PlayerInventory>().RemoveKey();
                //Allows for entering door
                door.canUseDoor = true;
                door.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                //Destroy Lock
                Destroy(gameObject);
            }
        }
    }


    IEnumerator LockDoor()
    {
        yield return new WaitForSeconds(0.1f);
        door.canUseDoor = false;
    }

}

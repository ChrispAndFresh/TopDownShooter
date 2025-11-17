using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/16/25
 * Allows player to pick up keys
 */

public class SmallKey : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if (other.gameObject.GetComponent<PlayerInventory>())
        {
            //Adds key to player inventory
            other.gameObject.GetComponent<PlayerInventory>().AddKey();
            //Removes key from game
            gameObject.SetActive(false);
        }
    }

}

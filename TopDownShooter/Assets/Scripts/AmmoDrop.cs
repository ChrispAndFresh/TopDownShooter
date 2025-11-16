using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Refills player ammo when picked up
 */

public class AmmoDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if (other.gameObject.GetComponent<PlayerInventory>())
        {
            //Refill ammo in currently held gun
            other.gameObject.GetComponent<PlayerInventory>().RefillGun();
            //Destroy pickup
            Destroy(gameObject);
        }
    }
}

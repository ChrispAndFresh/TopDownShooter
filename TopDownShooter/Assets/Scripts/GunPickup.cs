using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GunBase gun; //Reference to the gun the player picks up

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if(other.GetComponent<PlayerInventory>())
        {
            //Adds gun to player's inventory
            other.gameObject.GetComponent<PlayerInventory>().AddToInventory(gun);
            //Sets pickup to deactive
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gun; //Reference to the gun the player picks up

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if(other.GetComponent<PlayerController>())
        {
            //Adds gun to player's inventory
            other.gameObject.GetComponent<PlayerController>().PickupGun(gun);
            //Sets pickup to deactive
            gameObject.SetActive(false);
        }
    }
}

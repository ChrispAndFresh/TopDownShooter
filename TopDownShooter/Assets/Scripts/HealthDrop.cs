using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Refills player health when picked up
 */

public class HealthDrop : MonoBehaviour
{
    public int healing;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Heals the player
            other.gameObject.GetComponent<PlayerController>().GetHealed(healing);
            //Destroy pickup
            Destroy(gameObject);
        }  
    }
}

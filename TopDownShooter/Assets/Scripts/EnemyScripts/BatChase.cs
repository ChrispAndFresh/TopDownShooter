using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/18/25
 * Sets the bat enemy 
 */

public class BatChase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is entering is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            GetComponentInParent<Bat>().SetChasing(true);
        }
    }

}

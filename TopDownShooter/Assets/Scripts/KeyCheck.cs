using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/10/25
 * Checks if the player has a key in their inventory
 */

public class KeyCheck : MonoBehaviour
{
    //Text displayed when player has a key
    public GameObject text;

    private void Start()
    {
        text.SetActive(false); //Text starts out non-visible
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is entering is the player
        if (other.gameObject.GetComponent<PlayerInventory>())
        {
            //Checks if the player has any keys
            if (other.gameObject.GetComponent<PlayerInventory>().keys > 0)
            {
                text.SetActive(true); //Text becomes visible
            }
        }

    }

}

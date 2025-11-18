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
    Bat bat;

    private void Start()
    {
        bat = GetComponentInParent<Bat>();
    }


    private void Awake()
    {
        bat = GetComponentInParent<Bat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is entering is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            print('1');
            if (bat != null)
            {
                print('2');
                bat.SetChasing(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Checks if what is entering is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Sets the bat enemy to stop chasing the player
            if (bat != null)
            {
                bat.SetChasing(false);
            }
        }
    }
}

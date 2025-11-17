using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/16/25
 * Handles door mechanics
 */

public class Door : MonoBehaviour
{
    public Transform teleportPoint;
    public bool canUseDoor;


    private void Start()
    {
        canUseDoor = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (canUseDoor)
        {
            //Checks if what is colliding is the player
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                collision.gameObject.transform.position = teleportPoint.position;
            }
        }
    }
}

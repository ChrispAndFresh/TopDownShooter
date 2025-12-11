using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
Chase Phillips 
11/18/25
Handles the walls destruction.
*/
public class BreakableWall : MonoBehaviour
{
    //Possible wall that will also be destroyed upon one wall's destruction
    public GameObject otherWall;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the thing colliding with the wall is the player firing the bazooka at the wall.
        if (other.GetComponent<BazookaBullet>() != null)
        {
            if (otherWall != null)
            {
                Destroy(otherWall);
            }

            Destroy(gameObject);
        }
    }


}

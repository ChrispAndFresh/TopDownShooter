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
    private void OnTriggerEnter(Collider other)
    {
        //Checks if the thing colliding with the wall is the player firing the bazooka at the wall.
        if (other.GetComponent<BazookaBullet>() != null)
        {
            Destroy(gameObject);
        }
    }


}

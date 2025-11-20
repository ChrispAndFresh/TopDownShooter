using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Dominic Paxson
 * 11/20/25
 * Increases the players max HP
 */

public class IncreaseHP : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().IncreaseHealth();
            Destroy(gameObject);

        }
    }


}

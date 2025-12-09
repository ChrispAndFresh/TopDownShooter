using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
/*
12/9/25
Chase Phillips
Handles the movement and interaction of the secret wall doors.
*/
public class WallDoorScript : MonoBehaviour
{

    private float doorSpeed = 5;

    public Transform moveP;

    public Lever leverScript;

    private void Update()
    {
        StartCoroutine(WaitToErase());
    }



    /// <summary>
    /// Moves the door if the lever is activated and then 
    /// deactivates the door after it has moved out of the players way.
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitToErase()
    {
        if (leverScript.Active)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveP.position, doorSpeed * Time.deltaTime);
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}

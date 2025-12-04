using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class WallDoorScript : MonoBehaviour
{

    private float doorSpeed = 5;

    public Transform moveP;

    public Lever leverScript;

    private void Update()
    {

        if (leverScript.Active)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveP.position, doorSpeed * Time.deltaTime);
        }
    }
}

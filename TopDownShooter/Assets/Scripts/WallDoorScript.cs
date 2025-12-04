using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallDoorScript : MonoBehaviour
{

    public DoorScript doorScript;
    private float doorSpeed = 5;


    private void Start()
    {


    }


    private void Update()
    {

        //If the first door needs to move on the x or y axis then move.
        if (doorScript.openMoveX1P == true)
        {
            if (doorScript.leverscript.Active)
            {
                print("Joe");
            }



        }
        else if (doorScript.openMoveX1N == true)
        {
            if (doorScript.leverscript.Active)
            {
                print("Joe");
            }

        }
        //If the door doesn't need to move then don't
        else
        {


        }
        //If the second door needs to move on the x or y axis then move.
        if (doorScript.openMoveY1P == true)
        {

        }
        else if (doorScript.openMoveY1N == true)
        {

        }
        else
        {

        }




    }

}

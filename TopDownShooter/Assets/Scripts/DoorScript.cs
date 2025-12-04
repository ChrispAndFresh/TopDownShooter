using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/*
Chase Phillips 
11/20/25
Handles the opening and closing of special wall-doors.
*/



public class DoorScript : MonoBehaviour
{
    public Lever leverscript;

    public GameObject door1;
    public GameObject door2;

    public GameObject moveP1;

    public GameObject moveP2;

    public bool openMoveX1P;
    public bool openMoveX1N;
    public bool openMoveY1P;
    public bool openMoveY1N;
    public bool openMoveX2P;
    public bool openMoveX2N;
    public bool openMoveY2P;
    public bool openMoveY2N;




    private void Update()
    {
        Open();
    }

    /// <summary>
    /// Moves each individual door to it's designated move point
    /// </summary>
    public void Open()
    {

        //Checks if the first door needs to move on the x or y postiion to open.
        if (door1.transform.position.x > moveP1.transform.position.x)
        {
            openMoveX1P = true;
        }
        else if (door1.transform.position.x < moveP1.transform.position.x)
        {
            openMoveX1N = true;
        }
        else if (door1.transform.position.y > moveP1.transform.position.y)
        {
            openMoveY1P = true;
        }
        else if (door1.transform.position.y < moveP1.transform.position.y)
        {
            openMoveY1N = true;
        }
        else
        {
            //If the door is fully opened don't move anymore.
            openMoveX1P = false;
            openMoveX1N = false;
            openMoveY1P = false;
            openMoveY1N = false;
        }



        //Checks if the second door needs to move on the x or y position to open.
        //Checks if the first door needs to move on the x or y postiion to open.
        if (door2.transform.position.x > moveP1.transform.position.x)
        {
            openMoveX2P = true;
        }
        else if (door2.transform.position.x < moveP2.transform.position.x)
        {
            openMoveX2N = true;
        }
        else if (door2.transform.position.y > moveP2.transform.position.y)
        {
            openMoveY2P = true;
        }
        else if (door2.transform.position.y < moveP2.transform.position.y)
        {
            openMoveY2N = true;
        }
        else
        {
            //If the door is fully opened don't move anymore.
            openMoveX2P = false;
            openMoveX2N = false;
            openMoveY2P = false;
            openMoveY2N = false;
        }

    }





}

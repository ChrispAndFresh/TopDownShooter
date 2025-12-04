using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/4/25
 * Allows for opening/destroying of walls for level progression
 */

public class DoorSwitch : MonoBehaviour
{
    //Reference to the wall that will be opened
    public GameObject wall;

    //Determines if a switch has been activated or not
    private bool isActivated;

    //Material that the switch will swap to when activated
    public Material greenLight;

    private void Start()
    {
        isActivated = false; //Switch does not start active
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is a bullet
        if (other.gameObject.GetComponent<Bullet>())
        {
            //Checks if the switch has been activated
            if (!isActivated)
            {
                //Activates the switch
                ActivateSwitch();
            }
        }
    }

    void ActivateSwitch()
    {
        //Material Swap to indicate activation
        GetComponent<Renderer>().material = greenLight;

        //Light up a light
        wall.SetActive(false);

        //Switch has now been activated
        isActivated = true;
    }
}

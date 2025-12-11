using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/10/25
 * Allows for switching of active and inactive walls for puzzles
 */

public class ColorSwitch : MonoBehaviour
{
    //Colors the switch switches between
    public Material pink;
    public Material blue;

    //List of walls the switch switches on and off
    public List<GameObject> pinkWalls;
    public List<GameObject> blueWalls;

    //List of possible other switches that could be in a room;
    public List<ColorSwitch> otherSwitches;

    //Determines if the swtich has been turned "on" or "off"
    public bool active;

    //Gives a slight cool down before the switch can be interacted with agian
    private bool canBeSwitched;

    private void Start()
    {
        //Pink Walls start out inactive
        for (int i = 0; i < pinkWalls.Count; i++)
        {
            pinkWalls[i].SetActive(false);
        }

        //Switch starts off
        active = false;
        //Switch can be activated
        canBeSwitched = true;
    }


    private void OnTriggerStay(Collider other)
    {
        //Checks if the switch can be used
        if (canBeSwitched)
        {
            //Checks if what is colliding is the player
            if (other.gameObject.GetComponent<PlayerInventory>())
            {
                //If the player is interacting with the switch
                if (other.GetComponent<PlayerInventory>().interacting)
                {
                    print("Switch has been hit");
                    //If the switch is on, turn it off
                    if (active)
                    {
                        SwitchToBlue();
                        GetComponent<Renderer>().material = blue;

                        for (int i = 0; i < otherSwitches.Count; i++)
                        {
                            otherSwitches[i].gameObject.GetComponent<Renderer>().material = blue;
                        }
                    }
                    //If the siwtch is off, turn it on
                    else
                    {
                        SwitchToPink();
                        GetComponent<Renderer>().material = pink;

                        for (int i = 0; i < otherSwitches.Count; i++)
                        {
                            otherSwitches[i].gameObject.GetComponent<Renderer>().material = pink;
                        }
                    }

                    //turn off if on and on if off
                    active = !active;
                    for (int i = 0; i < otherSwitches.Count; i++)
                    {
                        otherSwitches[i].active = !active;
                    }

                    //Switch cannot be activated for a time
                    StartCoroutine(SwitchCooldown());

                }
            }
        }
    }

    //Switches the walls from pink to blue
    void SwitchToBlue()
    {
        //Set all pink walls to inactive
        for (int i = 0; i < pinkWalls.Count; i++)
        {
            pinkWalls[i].SetActive(false);
        }

        //Set all blue walls to active
        for (int i = 0;i < blueWalls.Count; i++)
        {
            blueWalls[i].SetActive(true);
        }
    }

    //Switches the walls from blue to pink
    void SwitchToPink()
    {
        //Set all blue walls to inactive
        for (int i = 0; i < blueWalls.Count; i++)
        {
            blueWalls[i].SetActive(false);
        }

        //Set all pink walls to active
        for (int i = 0; i < pinkWalls.Count; i++)
        {
            pinkWalls[i].SetActive(true);
        }
    }

    IEnumerator SwitchCooldown()
    {
        canBeSwitched = false;

        yield return new WaitForSeconds(0.3f);

        canBeSwitched = true;
    }
}

    



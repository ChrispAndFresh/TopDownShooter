using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/4/25
 * Opens a secret wall when all switches are activated
 */

public class SwitchWall : MonoBehaviour
{
    //List of lights to indicate how many swithces have been found/are left
    public List<Lights> lights;

    //Counts how many lights have been activated
    private int lightCount;

    private void Start()
    {
        lightCount = 0;
    }

    public void LightUpLight()
    {
        //Checks that lightCount has not gone past the scope of the list
        if (lightCount < lights.Count)
        {
            //Lights up one light
            lights[lightCount].LightUp();
            //Increase light count
            lightCount++;
        }

        //If all lights have been lit up
        if (lightCount == lights.Count)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                //Deactivate the lights
                lights[i].gameObject.SetActive(false);
            }

            //Deactivate the wall
            gameObject.SetActive(false);
        }

    }
}

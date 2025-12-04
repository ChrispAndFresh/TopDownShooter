using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 12/4/25
 * Controls the lights that indicate switch door progress
 */

public class Lights : MonoBehaviour
{
    //Checks for other scripts to see if the light is lit or not
    public bool isLit;

    //Material that the light will swap to when lit up
    public Material greenLight;

    private void Start()
    {
        //Light does not start out lit
        isLit = false;
    }


    /// <summary>
    /// Swaps the light's material and makes "isLit" true
    /// </summary>
    public void LightUp()
    {
        //Material Swap to indicate lighting up
        GetComponent<Renderer>().material = greenLight;

        //Light is now lit
        isLit=true;
    }
}

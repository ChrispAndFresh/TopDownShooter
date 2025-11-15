using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Chris Pimentel
 * 11/15/25
 * Controls function of the crossbow
 */

public class Crossbow : GunBase
{
    private float chargeTime; //Charge of gun
    public float chargeMax; //How long the gun needs to be charged to fire, to be set in inspector
    private float actualChargeMax; //Actual charge needed for gun 
    public Slider chargeSlider; //On screen representation of gun charge


    private void Awake()
    {
        //Actual charge used for calculations
        actualChargeMax = chargeMax * 100;

        //Sets values on sliders
        chargeSlider.maxValue = actualChargeMax;
    }

    // Update is called once per frame
    void Update()
    {
        GunFunctions();
        GunCharging();
    }


    /// <summary>
    /// Removes crossbow's ability to reload as it will happen automautically
    /// Changes firing of crossbow to holddown, charge, then release
    /// </summary>
    public override void GunFunctions()
    {
        if (canFire && (chamberAmmo > 0))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && GunCharging())
            {
                Fire();
                StartCoroutine(Cooldown());
            }
        }
    }


    /// <summary>
    /// Charges the gun when player holds down the left mouse button
    /// </summary>
    /// <returns>Returns true if gun is charged and false if not</returns>
    private bool GunCharging()
    {
        //Charges the gun when player holds down mouse 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Increases charge as mouse is held down
            chargeTime++;

            //Caps chargeTime
            if (chargeTime > actualChargeMax)
            {
                chargeTime = actualChargeMax;
            }

            //Updates slider
            chargeSlider.value = chargeTime;
        }

        //If player lets go of the mouse before firing, reset charge
        if (Input.GetKeyUp(KeyCode.Mouse0) && (chargeTime < actualChargeMax))
        {
            chargeTime = 0;
            chargeSlider.value = chargeTime;
        }

        //If gun is charged, return true
        if (chargeTime >= actualChargeMax)
        {
            return true;
        }
        //If gun is not charged, return false
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Sets charge back to 0 after bullet is fired;
    /// </summary>
    public override void Fire()
    {
        base.Fire();

        chargeTime = 0;
        chargeSlider.value = chargeTime;
    }

    /// <summary>
    /// Causes crossbow to reload automautically upon firing
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Cooldown()
    {
        //Player can no longer fire gun
        canFire = false;

        //Gun cooldown
        yield return new WaitForSeconds(cooldownTime);

        //Automautically reloads the rifle
        Reload();

        //Player can now fire gun
        canFire = true;
    }
}

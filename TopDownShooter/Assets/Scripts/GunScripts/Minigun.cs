using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Chris Pimentel
 * 11/15/25
 * Controls function of the minigun
 */

public class Minigun : GunBase
{
    //How many bullets the minigun creates each fire
    public int bulletNumber;

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
        CannotFireUntilCharged();
        GunCharging();
    }

    /// <summary>
    /// Stops the gun from firing until it is fully charged
    /// </summary>
    void CannotFireUntilCharged()
    {
        if (GunCharging())
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }


    /// <summary>
    /// Charges the gun if the player holds down the mouse key
    /// </summary>
    /// <returns>Returns true if gun is charged and false if not</returns>
    bool GunCharging()
    {
        //Charges if mouse is held down
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
        //Sets charge to 0 if mouse is let go
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            chargeTime = 0;
            chargeSlider.value = chargeTime;
        }

        //If gun is charged
        if (chargeTime >= actualChargeMax)
        {
            return true;
        }
        //If gun is not charged
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Minigun can hold down fire instead of just clicking
    /// </summary>
    public override void GunFunctions()
    {

        if (canFire && (chamberAmmo > 0))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Fire();
                StartCoroutine(Cooldown());
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    /// <summary>
    /// When minigun fires, create x bullets instead of 1
    /// </summary>
    public override void CreateBullet()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}

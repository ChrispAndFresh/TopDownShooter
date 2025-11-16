using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Controls function of the railgun
 */

public class Railgun : GunBase
{
    public float chargeTime; //Variable set in inspector to determine how long it takes to charge up the railgun
    private float actualChargeTime; //Actual variable used to determine chargeTime
    private float charge; //Determines percentage of charge time

    public GameObject fauxBullet; //Used to represent bullet charge on screen

    private void Awake()
    {
        //Sets actual chargeTime
        actualChargeTime = chargeTime * 100;

        //Sets bullet sprite to nonvisible
        fauxBullet.transform.localScale = new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        GunFunctions();
    }


    /// <summary>
    /// Has the player hold down the mouse button to charge and on release, fire bullet
    /// </summary>
    public override void GunFunctions()
    {
       
        if (canFire && (chamberAmmo > 0))
        {
            //When holding down mouse button charge gun
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ChargeGun();
            }
            //Upon release, fire gun
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Reset charge
                charge = 0;
                //Reset bullet sprite
                fauxBullet.transform.localScale = new Vector3(0f, 0f, 1f);
            
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
    /// Charges the gun up to actualMaxCharge
    /// </summary>
    void ChargeGun()
    {
        //Increase charge
        charge++;
        //Caps charge at maxCharge
        if (charge > actualChargeTime)
        {
            charge = actualChargeTime;
        }

        float chargePercent = charge / actualChargeTime;
        fauxBullet.transform.localScale = new Vector3(chargePercent * 2, chargePercent * 2, 1f);
        print("Gun Charging: " + ((charge / actualChargeTime) * 100) + "%");
    }
    

    public float PassChargePercent()
    {
        return (charge / actualChargeTime);
    }
}

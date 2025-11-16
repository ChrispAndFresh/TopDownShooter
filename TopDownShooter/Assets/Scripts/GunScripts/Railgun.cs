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
    private float chargePercent; //Value that gets passed to bullet

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
        }

        //Upon release, if there is charge, fire gun
        if (Input.GetKeyUp(KeyCode.Mouse0) && charge > 0)
        {
            //Reset charge
            charge = 0;
            //Reset bullet sprite
            fauxBullet.transform.localScale = new Vector3(0f, 0f, 1f);

            Fire();
            StartCoroutine(Cooldown());
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

        if (charge > 0 && (charge % 10 == 0))
        {
            chamberAmmo--;
        }
       
        chargePercent = charge / actualChargeTime;
        fauxBullet.transform.localScale = new Vector3(chargePercent * 2, chargePercent * 2, 1f);
        print("Gun Charging: " + ((charge / actualChargeTime) * 100) + "%");

    }


    /// <summary>
    /// Railgun no longer removes ammo on fire as it happens else where
    /// </summary>
    public override void Fire()
    {
        CreateBullet();
    }

    //When bullet spawns, pass info
    private void OnTriggerStay(Collider other)
    {
        //Checks if what is in the trigger is the railgun bullet
        if (other.gameObject.GetComponent<RailgunBullet>())
        {
            other.gameObject.GetComponent<RailgunBullet>().AdjustBullet(chargePercent);
        }
    }
}

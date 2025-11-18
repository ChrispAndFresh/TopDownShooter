using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/13/25
 * Template for every gun script. Holds variables for ammo, cooldown, 
 * and bullet prefabs.
 */

public class GunBase : MonoBehaviour
{
    public int chamberAmmo; //How many bullets the gun has in the chamber
    public int chamberAmmoMax; //How many bullets the gun can have in the chamber
    public int ammoCount; //Total ammount of bullets the gun has
    public int ammoMax; //Max ammount of bullets the gun can have

    public float cooldownTime; //Determines how long it takes to fire the gun agian
    public bool canFire = true; //Used to dictate when a gun can and cannot fire
    public GameObject bulletPrefab; //Reference to the bullet each gun fires

    public Transform firePoint; //Where the bullet spawns

    public int refillAmount; //How much ammo a gun gains from an ammo drop

    //public UI_Display ammoOnUI; //Reference to ammo count on UI


    /// <summary>
    /// Allows for basic functions of gun, firing and reloading
    /// </summary>
    public virtual void GunFunctions()
    {
        if (canFire && (chamberAmmo > 0))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
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
    /// Template function to be overridden for each gun
    /// </summary>
    public virtual void Fire()
    {
        CreateBullet();
        --chamberAmmo;
    }
    

    /// <summary>
    /// Creates one instance of a bullt
    /// </summary>
    public virtual void CreateBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    /// <summary>
    /// Sets ammo in gun to full
    /// </summary>
    public void SetAmmoToFull()
    {
        chamberAmmo = chamberAmmoMax;
        ammoCount = ammoMax;
    }


    /// <summary>
    /// Reloads guns, adds ammo to "chamber" and subtracts from "total"
    /// </summary>
    public void Reload()
    {

        int reloadAmount = chamberAmmoMax - chamberAmmo;

        //If there aren't enough bullets to relaod the gun
        if (reloadAmount > ammoCount)
        {
            //Adds the final bullets to the "chamber"
            chamberAmmo += ammoCount;
            //Removes bullets from total ammo count
            ammoCount -= ammoCount;
        }
        //If there are plenty of bullets left to reload
        else
        {
            //Add the needed bullets to "chamber"
            chamberAmmo += reloadAmount;
            //Remove needed bullets from total ammo count
            ammoCount -= reloadAmount;
        }


    }


    /// <summary>
    /// When player collects a ammo refill, refill ammo
    /// </summary>
    public virtual void RefillAmmo()
    {
        //adds refill amount to ammo
        ammoCount += refillAmount;
        chamberAmmo = chamberAmmoMax;

        //Caps ammo at max
        if (ammoCount > ammoMax)
        {
            ammoCount = ammoMax;
        }
    }

    /// <summary>
    /// Controls cooldown for each gun
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Cooldown()
    {
        //Player can no longer fire gun
        canFire = false;

        //Gun cooldown
        yield return new WaitForSeconds(cooldownTime);

        //Player can now fire gun
        canFire = true;
    }
}

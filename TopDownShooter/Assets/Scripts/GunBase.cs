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


    /// <summary>
    /// Template function to be overridden for each gun
    /// </summary>
    public virtual void Fire()
    {
        chamberAmmo--;
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
    /// Controls cooldown for each gun
    /// </summary>
    /// <returns></returns>
    public IEnumerator Cooldown()
    {
        //Player can no longer fire gun
        canFire = false;

        //Gun cooldown
        yield return new WaitForSeconds(cooldownTime);

        //Player can now fire gun
        canFire = true;
    }
}

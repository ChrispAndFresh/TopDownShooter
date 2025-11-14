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
    public int ammo;
    public int ammoMax;
    public float cooldownTime;
    public bool canFire = true;
    public GameObject bulletPrefab;


    public virtual void Fire()
    {

    }
    
    public void SetAmmo()
    {
        ammo = ammoMax;
    }


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

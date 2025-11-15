using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/14/25
 * Controls function of the Rifle
 */

public class Rifle : GunBase
{
    // Update is called once per frame
    void Update()
    {
        GunFunctions();
    }


    /// <summary>
    /// Removes rifle's ability to reload as it will happen automautically
    /// </summary>
    public override void GunFunctions()
    {
        if (canFire && (chamberAmmo > 0))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
                StartCoroutine(Cooldown());
            }
        }
    }


    /// <summary>
    /// Causes rifle to reload automautically upon firing
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

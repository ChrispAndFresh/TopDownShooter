using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/14/25
 * Controls function of the flamethrower
 */

public class Flamethrower : GunBase 
{
    //How many bullets the flamethrower creates each fire
    public int bulletNumber;

    // Update is called once per frame
    void Update()
    {
        GunFunctions();
    }

    /// <summary>
    /// Flamethrower can hold down fire instead of just clicking
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
    /// When flamethrower fires, create x bullets instead of 1
    /// </summary>
    public override void CreateBullet()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}

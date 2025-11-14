using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/13/25
 * Script to test gun functions
 */

public class TestGun : GunBase
{
    private void Update()
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

    public override void Fire()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        chamberAmmo--;
    }
}

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
        if (canFire)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
                StartCoroutine(Cooldown());
            }
        }
    }

    public override void Fire()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}

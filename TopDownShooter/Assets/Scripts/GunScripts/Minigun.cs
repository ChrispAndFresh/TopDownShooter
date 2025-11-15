using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : GunBase
{
    //How many bullets the minigun creates each fire
    public int bulletNumber;

    // Update is called once per frame
    void Update()
    {
        GunFunctions();
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

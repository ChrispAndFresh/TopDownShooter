using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/14/25
 * Controls function of the shotgun
 */

public class Shotgun : GunBase
{
    //How many bullets the shotgun creates each fire
    public int bulletNumber; 

    // Update is called once per frame
    void Update()
    {
        GunFunctions();
    }

    /// <summary>
    /// When shotgun fires, create 6 bullets instead of 1
    /// </summary>
    public override void CreateBullet()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }


}

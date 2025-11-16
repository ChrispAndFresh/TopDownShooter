using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Adjusts speed, damage, and size of bullet based off of railgun charge percent
 */

public class RailgunBullet : MonoBehaviour
{
    //Controls if a bullet can be adjusted
    bool canBeAdjusted;

    private void Awake()
    {
        //Bullet can be adjusted when spawned
        canBeAdjusted = true;
    }

    /// <summary>
    /// Adjust bullet based off of charge percent from railgun
    /// </summary>
    /// <param name="percent"></param>
    public void AdjustBullet(float percent)
    {
        if (canBeAdjusted)
        {
            //Adjusts size of bullet
            gameObject.transform.localScale = new Vector3(percent * 2, percent * 2, 1f);

            //Adjusts damage of bullet
            float newDamage = GetComponent<Bullet>().damage * percent;
            //Rounds down float to int
            GetComponent<Bullet>().damage = Mathf.FloorToInt(newDamage);

            //Adjusts speed of bullet
            float newSpeed = GetComponent<Bullet>().speed / percent;
            //Rounds down float to int
            GetComponent<Bullet>().speed = Mathf.FloorToInt(newSpeed);
        }

        canBeAdjusted = false;
    }

}

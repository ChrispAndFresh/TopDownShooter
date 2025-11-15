using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Allows for critchance for magnum bullets
 */

public class MagnumBullet : MonoBehaviour
{
    //Percentage out of 100 that the bullet lands a critical hit
    public float critChance;

    private void Awake()
    {
        float critSuccess = Random.Range(0, 99);

        if (critSuccess <= critChance)
        {
            GetComponent<Bullet>().damage *= 3;
        }

        print("Bullet damage: " + GetComponent<Bullet>().damage);
    }
}

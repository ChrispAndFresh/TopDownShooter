using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/14/25
 * Adds special effects to bazooka bullets
 */

public class BazookaBullet : MonoBehaviour
{
    private float oldSpeed; //Stores the original speed of bullet
    public float newSpeed; //How slow the bullet will travel for a short period of time
    public float pauseTime; //Determines how long bullet should hang in the air

    private void Awake()
    {
        //Stores original speed
        oldSpeed = GetComponent<Bullet>().speed;
        
        //Sets bullet speed to slow
        GetComponent<Bullet>().speed = newSpeed;

        //Causes bullet to hang before moving faster
        StartCoroutine(RocketPause(pauseTime));
    }

    private void OnDestroy()
    {
        
    }

    private IEnumerator RocketPause(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
        GetComponent<Bullet>().speed = oldSpeed;
    }
}

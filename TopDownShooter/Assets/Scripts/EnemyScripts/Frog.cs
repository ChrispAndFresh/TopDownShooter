using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/28/25
 * Controls behavior of Frog enemy
 */

public class Frog : Enemy
{
    bool isDropping; //Determines if frog is dropping
    bool isRising; //Determines if frog is rising
    Vector3 maxPoint; //How far up the frog will move

    Rigidbody rb; //Reference to rigidbody for movement
    FrogShadow shadow; //Reference to Frog's shadow for movement

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        shadow = GetComponentInParent<FrogShadow>();

        //Sets max point to current point
        maxPoint = gameObject.transform.position;

        isDropping = true; //Frog starts out dropping
        isRising = false; //Frog does not start out rising
    }

    void FixedUpdate()
    {
        if (isDropping)
        {
            //Checks if the frog is above the shadow
            if (transform.position.y > (shadow.gameObject.transform.position.y + 1))
            {
                rb.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);
            }

            //If the frog is on its shadow, drop no longer
            else if (transform.position.y <= shadow.gameObject.transform.position.y)
            {
                isDropping = false;
                GetComponent<BoxCollider>().enabled = true; //Frog can be hit when it lands
            }
        }

        if (isRising)
        {
            //Checks if the frog is below its max point
            if (transform.position.y < maxPoint.y)
            {
                GetComponent<BoxCollider>().enabled = false; //Frog can not be hit when it rises
                rb.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);
            }

            //IF the frog is at its max point, rise no longer
            else if (transform.position.y >= maxPoint.y)
            {
                isRising = false;
            }
        }
    }


    /// <summary>
    /// Sets isDropping to true
    /// </summary>
    public void SetDropToTrue()
    {
        isDropping = true;
        print("Frog drops");
    }


    /// <summary>
    /// Sets isRising to true
    /// </summary>
    public void SetRiseToTrue()
    {
        isRising = true;
        print("Frog rises");
    }


    /// <summary>
    /// Checks if frog is rising
    /// </summary>
    /// <returns></returns>
    public bool IsRising()
    {
        return isRising;
    }
}

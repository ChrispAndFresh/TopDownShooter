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

    public GameObject healthIncrease; //Frog will drop a health upgrade upon death
    public GameObject key; //Frog will drog a key upon death


    private void Awake()
    {
        //Sets health, speed, and reset point
        SetStartingValues();

        rb = GetComponent<Rigidbody>();
        shadow = GetComponentInParent<FrogShadow>();

        //Sets max point to current point
        maxPoint = gameObject.transform.position;


        GetComponent<BoxCollider>().enabled = false; //Frog can not be hit as it starts out dropping
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
            else if (transform.position.y <= shadow.gameObject.transform.position.y + 1)
            {
                isDropping = false;
                GetComponent<BoxCollider>().enabled = true; //Frog can be hit when it lands
                print("Frog is no longer dropping");
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




    /// <summary>
    /// When Frog dies, destroy the shadow as well
    /// </summary>
    public override void Die()
    {
        //Create the health upgrade
        Instantiate(healthIncrease, shadow.GetSpawnPoint().position + new Vector3(-1f, 0f, 0f), shadow.GetSpawnPoint().rotation);
        //Create a key
        Instantiate(key, shadow.GetSpawnPoint().position + new Vector3(1f, 0f, 0f), shadow.GetSpawnPoint().rotation);

        //Destroys shadow
        Destroy(shadow.gameObject);

        //Disables enemy
        gameObject.SetActive(false);
       

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/18/25
 * Handles behavior of bat enemies
 */

public class Bat : Enemy
{
    public bool isChasing;

    // Start is called before the first frame update
    void Start()
    {
        SetStartingValues();
        isChasing = false;
    }

    void Awake()
    {
        SetStartingValues();
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing && isActive)
        {
            MoveToPlayer();
        }
    }


    /// <summary>
    /// Moves the bat to the player's location
    /// </summary>
    void MoveToPlayer()
    {
        //Moves the bat left 
        if (transform.position.x > PlayerController.playerPos.x)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //Moves the bat right
        else if (transform.position.x < PlayerController.playerPos.x)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Moves the bat down
        if (transform.position.y > PlayerController.playerPos.y)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        //Moves the bat up
        else if (transform.position.y < PlayerController.playerPos.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }

    
    /// <summary>
    /// Sets if the bat will chase the player
    /// </summary>
    /// <param name="willChase"></param>
    public void SetChasing(bool willChase)
    {
        isChasing = willChase;
    }


    /// <summary>
    /// When resetting the bat, isChasing will no longer be true
    /// </summary>
    public override void ResetEnemy()
    {
        base.ResetEnemy();
        isChasing = false;
    }


}

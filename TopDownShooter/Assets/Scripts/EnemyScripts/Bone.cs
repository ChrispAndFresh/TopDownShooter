using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/19/25
 * Controls the projectile the skeleton enemy throws
 */

public class Bone : MonoBehaviour
{
    private Vector3 targetPos; //Where the bone is headed too
    private Vector3 trajectory; //Direction the bone moves

    public int speed; //How fast the bone travels
    public int damage; //How much damage the projectile does

    private void Awake()
    {
        //Get the player's location
        targetPos = PlayerController.playerPos;
        
        //Find the tragetory the bone needs to follow to move towards targetPos
        trajectory = targetPos - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += trajectory * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is colliding is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Damages the player
            other.gameObject.GetComponent<PlayerController>().GetDamaged(damage);
        }


        print(other.gameObject.name);
        Destroy(gameObject);
        
    }
}

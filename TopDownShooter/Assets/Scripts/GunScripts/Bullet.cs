using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/13/25
 * Controls behavior for bullets
 */

public class Bullet : MonoBehaviour
{
    public float speed; //Controls bullet speed
    public int damage; //Controls bullet damage
    public float spray; //How much a bullet will spray when fired
    private Vector3 sprayOffset;


    private void Awake()
    {
        //Gives bullet spray
        sprayOffset = new Vector3(Random.Range(-spray, spray), Random.Range(-spray, spray), 0f);
        sprayOffset.x += 1f;
        sprayOffset.Normalize();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sprayOffset * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        //If colliding with enemy, damage it

        //Checks if what is colliding should not destroy bullets
        if (other.gameObject.GetComponent<DontDestroyBullets>() == null && other.GetComponent<Bullet>() == null)
        {
            //Destroy bullet on contact
            Destroy(gameObject);
        }
    }
}

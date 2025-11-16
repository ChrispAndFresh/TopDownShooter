using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/15/25
 * Holds basic variables for enemy and allows them to damage and be damaged
 */

public class Enemy : MonoBehaviour
{
    public int health; //How much health the enemy has
    public int contactDamage; //How much damage the enemy deals on contact
    public int dropRate; //How high of a chance the enemy has to drop something upon death
    public int speed; //How fast the enemy is

    public GameObject healthDrop; //Prefab of health drop
    public GameObject ammoDrop; //Prefab of ammo drop

    public void GetDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        int dropSuccess = Random.Range(0, 99);

        if (dropSuccess <= dropRate)
        {
            int dropChoice = Random.Range(1, 3);
            print(dropChoice);
            if (dropChoice <= 1)
            {
                Instantiate(healthDrop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(ammoDrop, transform.position, transform.rotation);
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamaged(contactDamage);
        }
    }
}

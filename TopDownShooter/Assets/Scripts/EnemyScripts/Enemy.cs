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
    public int maxHealth; //How much health the enemy can have
    public int contactDamage; //How much damage the enemy deals on contact
    public int dropRate; //How high of a chance the enemy has to drop something upon death
    public int speed; //How fast the enemy is

    public GameObject healthDrop; //Prefab of health drop
    public GameObject ammoDrop; //Prefab of ammo drop

    public Vector3 startingPos; //Starting Position of enemy for resetting

    public bool isActive; //Determines if enemy is active or not

    public RoomManager roomManager; //Reference to the enemies' room's RoomManager

    public void SetStartingValues()
    {
        startingPos = transform.position;
        health = maxHealth;
        isActive = false;
    }


    private void OnBecameVisible()
    {
        print("Enemy is VIsible");
        isActive = true;
    }

    /// <summary>
    /// Takes health away from enemy
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }


    /// <summary>
    /// Destroys the enemy and possibly drops ammo or health
    /// </summary>
    public virtual void Die()
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

        //Disables enemy
        gameObject.SetActive(false);
        //Checks if room should spawn item
        roomManager.SpawnItem();

    }


    /// <summary>
    /// When colliding with the player, damage the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamaged(contactDamage);
        }
    }


    /// <summary>
    /// Resets enemy to starting location, health to max, and isActive to false
    /// </summary>
    public virtual void ResetEnemy()
    {
        health = maxHealth;
        transform.position = startingPos;
        isActive = false;
    }
}

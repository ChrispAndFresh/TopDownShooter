using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/29/25
 * Handles behavior of Frog's shadow
 */

public class FrogShadow : MonoBehaviour
{
    public float InitialStartWait; //How long is takes before the shadow starts to move
    public float JumpWaitTime; //How long between attacks
    public float followTime; //How long the shadow follows the player before the frog attacks

    private bool moving; //Determines if shadow is moving
    private Vector3 directionToPlayer;
    public float speed; //How fast the shadow moves

    private Frog frog; //Reference to the frog enemy

    private Transform spawnPoint; //Reference to where the frog spawns to drop items

    public MiniBossRoomManager room; //Refernce to the room the miniboss is in

    void Awake()
    {
        spawnPoint = transform;

        frog = GetComponentInChildren<Frog>();

        moving = false;

        InvokeRepeating("MoveToPlayer", InitialStartWait, JumpWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            directionToPlayer = PlayerController.playerPos - transform.position;
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }


    /// <summary>
    /// Starts coroutine to have frog "attack"
    /// </summary>
    void MoveToPlayer()
    {
        StartCoroutine(SetMovingToTrue());
    }


    /// <summary>
    /// Sets bool "moving" to true for a period of time
    /// </summary>
    /// <returns></returns>
    IEnumerator SetMovingToTrue()
    {
        //Frog rises up
        frog.SetRiseToTrue();
        
        //Wait unit frog rises
        yield return new WaitUntil(() => !frog.IsRising());

        //Shadow starts to move
        moving = true;

        //Wait a period of time
        yield return new WaitForSeconds(followTime);

        //Shadow no longer moves
        moving = false;

        //Frog drops down
        frog.SetDropToTrue();
    }


    /// <summary>
    /// Get the spawnpoint from the shadow
    /// </summary>
    /// <returns></returns>
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }


    public void Die()
    {
        room.RemoveWalls();

        Destroy(gameObject);
    }
}

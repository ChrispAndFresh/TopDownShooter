using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/13/25
 * Controls player's inventory
 */

public class PlayerInventory : MonoBehaviour
{
    //Array to hold guns in inventory
    public GunBase[] gunInventory;
    //Starting size for inventory
    public int maxInventory = 5;

    public GunBase noGun; //Reference to "gun" in player's starting inventory
    public Transform gunSlot; //Reference to where guns are held on the player


    void Start()
    {
        //Sets inventory size
        gunInventory = new GunBase[maxInventory];
        //Sets first gun in inventory as starting "gun"
        AddToInventory(noGun);
    }


    /// <summary>
    /// When colliding with a gun pickup, add gun to inventory if there is space
    /// </summary>
    /// <param name="gun"></param>
    public bool AddToInventory(GunBase gun)
    {
        //Cycles through inventory until end of inventory is reached or new gun is added
        bool success = false;
        for (int i = 0; i < gunInventory.Length && !success; i++)
        {
            //If there is an empty spot in the inventory
            if (gunInventory[i] == null)
            {
                //Add gun to inventory
                gunInventory[i] = gun;
                //Set gun's ammo to full
                gunInventory[i].GetComponent<GunBase>().SetAmmoToFull();
                //Creates the gun
                Instantiate(gunInventory[i], gunSlot);
                //Set trigger to end loop to true
                success = true;

                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(i);
            }
        }

        return success;
    }


    /// <summary>
    /// Cycles through player's inventory and sets all guns to deactive
    /// </summary>
    private void SetAllGunsToFalse()
    {
        print("All guns set to deactive");
        //Cycles through inventory
        for (int i = 0; i < gunInventory.Length; i++)
        {
            //If there is a gun in this inventory
            if (gunInventory[i] != null)
            {
                //Set gun in inventory space to false
                gunInventory[i].gameObject.SetActive(false);
            }
        }
    }
    


    /// <summary>
    /// Sets the gun in inventory[index] to active
    /// </summary>
    /// <param name="index"></param>
    private void SetGunToActive(int index)
    {
        print("Gun set to active");
        //Checks index is within range and there is a gun in inventory[index]
        if ((index < gunInventory.Length) && gunInventory[index] != null)
        {
            gunInventory[index].gameObject.SetActive(true);
        }
    }
}

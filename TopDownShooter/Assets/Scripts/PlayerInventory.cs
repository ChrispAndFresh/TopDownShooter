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


    void Start()
    {
        //Sets inventory size
        gunInventory = new GunBase[maxInventory];
        //Sets first gun in inventory as starting "gun"
        gunInventory[0] = noGun;
    }

    public void AddToInventory(GunBase gun)
    {
        bool success = false;
        for (int i = 0; i < gunInventory.Length && !success; i++)
        {
            if (gunInventory[i] == null)
            {
                gunInventory[i] = gun;
                gun.GetComponent<GunBase>().SetAmmoToFull();
                success = true;
            }
        }
    }


    /// <summary>
    /// Returns starting gun "noGun" if index is null or outside of inventory
    /// Otherwise returns the gun at index 
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    public GunBase GetGunFromSlot(int slot)
    {
        //If number index goes outside of inventory space, return first gun
        if (slot >= gunInventory.Length)
        {
            return gunInventory[0];
        }
        //If inventory space has no gun, return first gun
        else if (gunInventory[slot] == null)
        {
            return gunInventory[0];
        }
        //If index has a gun, return gun
        else
        {
            return gunInventory[slot];
        }
    }
}

using System;
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
    public int maxInventory = 10;

    public GunBase noGun; //Reference to "gun" in player's starting inventory
    public Transform gunSlot; //Reference to where guns are held on the player

    public UI_Display ammoOnUI; //Reference to UI to update ammo count
    private int currentIndex; //Reference to index of gun player is currently holding


    void Start()
    {
        //Sets inventory size
        gunInventory = new GunBase[maxInventory];
        //Sets first gun in inventory as starting "gun"
        AddToInventory(noGun);
    }


    private void Update()
    {
        SetGunInHand();

        //Update UI
        ammoOnUI.UpdateAmmoOnUI(gunInventory[currentIndex].chamberAmmo, gunInventory[currentIndex].ammoCount);
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
                //Creates the gun and adds it to inventory
                gunInventory[i] = Instantiate(gun, gunSlot);
                //Sets ammo to full
                gunInventory[i].GetComponent<GunBase>().SetAmmoToFull();
                //Set trigger to end loop to true
                success = true;

                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(i);

                //Update UI
                currentIndex = i;
            }
        }

        return success;
    }



    private void SetGunInHand()
    {
        //if player presses 0, switch to gun in slot 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[0] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(0);
                //Update UI
                currentIndex = 0;
            }
        }

        //if player presses 1, switch to gun in slot 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //If slot 1 has a gun, switch guns
            if (gunInventory[1] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(1);
                //Update UI
                currentIndex = 1;
            }
        }

        //if player presses 2, switch to gun in slot 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //If slot 2 has a gun, switch guns
            if (gunInventory[2] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(2);
                //Update UI
                currentIndex = 2;
            }
        }

        //if player presses 3, switch to gun in slot 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //If slot 3 has a gun, switch guns
            if (gunInventory[3] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(3);
                //Update UI
                currentIndex = 3;
            }
        }

        //if player presses 4, switch to gun in slot 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[4] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(4);
                //Update UI
                currentIndex = 4;
            }
        }

        //if player presses 5, switch to gun in slot 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //If slot 5 has a gun, switch guns
            if (gunInventory[5] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(5);
                //Update UI
                currentIndex = 5;
            }
        }

        //if player presses 6, switch to gun in slot 6
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[6] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(6);
                //Update UI
                currentIndex = 6;
            }
        }

        //if player presses 7, switch to gun in slot 7
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[7] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(7);
                //Update UI
                currentIndex = 7;
            }
        }

        //if player presses 8, switch to gun in slot 8
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[8] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(8);
                //Update UI
                currentIndex = 8;
            }
        }

        //if player presses 9, switch to gun in slot 9
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //If slot 0 has a gun, switch guns
            if (gunInventory[9] != null)
            {
                //Sets all guns to false
                SetAllGunsToFalse();
                //Sets new gun to active
                SetGunToActive(9);
                //Update UI
                currentIndex = 9;
            }
        }

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
                print("Deactivated gun: " + i);
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
        print("Gun set to active" + index);
        //Checks index is within range and there is a gun in inventory[index]
        if ((index < gunInventory.Length) && gunInventory[index] != null)
        {
            gunInventory[index].gameObject.SetActive(true);
            gunInventory[index].canFire = true;
        }
    }


    /// <summary>
    /// Refills gun player has in hand
    /// </summary>
    /// <param name="refill"></param>
    public void RefillGun()
    {
        gunInventory[currentIndex].RefillAmmo();
    }
}

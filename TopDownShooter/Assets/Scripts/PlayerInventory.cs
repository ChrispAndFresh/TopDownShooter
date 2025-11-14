using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //Array to hold guns in inventory
    public GunBase[] gunInventory;
    //Starting size for inventory
    public int maxInventory = 5;


    void Start()
    {
        gunInventory = new GunBase[maxInventory];
    }

    public void AddToInventory(GunBase gun)
    {
        bool success = false;
        for (int i = 0; i < gunInventory.Length && !success; i++)
        {
            if (gunInventory[i] == null)
            {
                gunInventory[i] = gun;
                success = true;
            }
        }
    }
}

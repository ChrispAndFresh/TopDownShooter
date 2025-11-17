using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/*
 * Chris Pimentel
 * 11/15/25
 * Handles Health, Ammo, and Inventory on UI
 */

public class UI_Display : MonoBehaviour
{
    public TMP_Text ammoCount;
    public GameObject[] hearts;
    public GameObject[] keys;
    public GameObject bigKey;

    /// <summary>
    /// Sets numbers on UI to reflect ammo in gun
    /// </summary>
    /// <param name="ammoInChamber"></param>
    /// <param name="ammoTotal"></param>
    public void UpdateAmmoOnUI(int ammoInChamber, int ammoTotal)
    {
        ammoCount.text = "" + ammoInChamber + " / " + ammoTotal;
    }


    /// <summary>
    /// Sets as many hearts active as player health
    /// </summary>
    /// <param name="health"></param>
    public void UpdateHealthOnUI(int health)
    {
        DeactivateHearts();

        for (int i = 0; i < hearts.Length && i < health; i++)
        {
            hearts[i].SetActive(true);
        }
    }


    /// <summary>
    /// Sets all hearts on UI as deactive
    /// </summary>
    private void DeactivateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
    }


    /// <summary>
    /// Sets the amount of Keys on UI
    /// </summary>
    /// <param name="keyAmount"></param>
    public void SetKeysOnUI(int keyAmount)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (i <  keyAmount)
            {
                keys[i].SetActive(true);
            }
            else
            {
                keys[i].SetActive(false);
            }
        }
    }



    /// <summary>
    /// Shows on UI if player has the Big Key
    /// </summary>
    /// <param name="hasBigKey"></param>
    public void SetBigKeyOnUI(bool hasBigKey)
    {
        if (hasBigKey)
        {
            bigKey.SetActive(true);
        }
        else
        {
            bigKey.SetActive(false);
        }
    }
}

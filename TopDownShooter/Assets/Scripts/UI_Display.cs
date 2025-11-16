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
}

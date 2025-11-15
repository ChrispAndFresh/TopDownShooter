using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Display : MonoBehaviour
{
    public TMP_Text ammoCount;

    public void UpdateAmmoOnUI(int ammoInChamber, int ammoTotal)
    {
        ammoCount.text = "" + ammoInChamber + " / " + ammoTotal;
    }
}

using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammoText;
    [SerializeField]
    FloatVariable currentAmmo;
    public void UpdateUI() {
        ammoText.SetText(currentAmmo.Value.ToString());
    }
}

using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    FloatVariable stamina;

    [SerializeField]
    Image staminaBar;

    public void UpdateStamina() {
        staminaBar.fillAmount = stamina.Value / 100f;
    }
}

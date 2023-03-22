using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField]
    Image reloadBar;
    [SerializeField]
    FloatVariable weaponReloadTime;
    [SerializeField]
    BoolVariable isReloading;

    float t;
    void Start()
    {
        reloadBar.fillAmount = 0;
    }

    public void FillReloadBar() {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine() {
        t = 0;
        isReloading.Value = true;
        while (t < 1) {
            yield return null;
            t += Time.deltaTime / weaponReloadTime.Value;
            reloadBar.fillAmount = t;
        }
        reloadBar.fillAmount = 0;
        isReloading.Value = false;
    }
}

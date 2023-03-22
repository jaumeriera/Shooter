using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    // TODO configure by scriptable
    [SerializeField]
    int totalAmmo;
    [SerializeField]
    float timeToReload;

    [SerializeField]
    GameEvent UpdateAmmo;
    [SerializeField]
    GameEvent StartReloadAnim;
    [SerializeField]
    FloatVariable currentAmmo;

    private void Start() {
        currentAmmo.Value = totalAmmo;
        UpdateAmmo.Raise();
    }

    public void ShotPerformed() {
        currentAmmo.Value -= 1;
        UpdateAmmo.Raise();
    }

    public void Reload() {
        StartCoroutine(DoReload());
    }

    private IEnumerator DoReload() {
        currentAmmo.Value = 0;
        UpdateAmmo.Raise();
        StartReloadAnim.Raise();
        yield return new WaitForSeconds(timeToReload);
        currentAmmo.Value = totalAmmo;
        UpdateAmmo.Raise();
    }
}

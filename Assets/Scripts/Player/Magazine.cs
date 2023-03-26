using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    // TODO configure by scriptable
    [SerializeField]
    WeaponScriptableObject _settings;

    [SerializeField]
    FloatVariable weaponReloadTime;
    [SerializeField]
    GameEvent UpdateAmmo;
    [SerializeField]
    GameEvent StartReloadAnim;
    [SerializeField]
    FloatVariable currentAmmo;

    private void Start() {
        currentAmmo.Value = _settings.totalAmmo;
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
        // This asignation is done each time because in the future maybe we would
        // like to implement more weapons, in this case, we just need to change 
        // the scriptable object and before reload, we send the correct reload
        // time
        weaponReloadTime.Value = _settings.timeToReload;
        currentAmmo.Value = 0;

        UpdateAmmo.Raise();
        StartReloadAnim.Raise();
        yield return new WaitForSeconds(_settings.timeToReload);
        currentAmmo.Value = _settings.totalAmmo;
        UpdateAmmo.Raise();
    }
}

using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("External dependencies")]
    [SerializeField]
    ParticleSystem smoke;
    [SerializeField]
    Camera mainCamera;

    [Header("Shot variables")]
    [SerializeField]
    GameEvent shootPerformed;
    [SerializeField]
    GameEvent emptyShoot;
    [SerializeField]
    FloatVariable currentAmmo;
    [SerializeField]
    float cooldown = 1f;

    [Header("Reload")]
    [SerializeField]
    BoolVariable isReloading;
    [SerializeField]
    GameEvent ReloadWeapon;

    RaycastHit hit;
    float t;

    private void Start() {
        t = cooldown;
    }

    void Update()
    {
        // Check this in order to prevent float overflow
        if (t < cooldown) {
            t += Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1")) {
            if (CanShoot()) {
                shootPerformed.Raise();
                smoke.Stop();
                smoke.Play();
                // TODO play sound
                t = 0;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity)) {
                    if (hit.collider.gameObject.layer == (int)Layers.Target) {
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            } else if (!isReloading.Value && t >= cooldown) {
                emptyShoot.Raise();
            }

        } else if (Input.GetButtonDown("Reload") && !isReloading.Value) {
            ReloadWeapon.Raise();
        }
    }

    private bool CanShoot() {
        return HasEnoughAmmo() && t >= cooldown;
    }

    private bool HasEnoughAmmo() {
        return currentAmmo.Value > 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Shoot : MonoBehaviour
{
    [Header("External dependencies")]
    [SerializeField]
    ParticleSystem smoke;
    [SerializeField]
    Camera mainCamera;
    [Header("Shot variables")]
    [SerializeField]
    float range;
    [SerializeField]
    float cooldown = 1f;

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

        if (Input.GetButtonDown("Fire1") && CanShoot()) {
            smoke.Stop();
            smoke.Play();
            // TODO play sound
            t = 0;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range)) {
                if (hit.collider.gameObject.layer == (int)Layers.Target) {
                    hit.collider.gameObject.SetActive(false);
                }
            }

        }
    }

    private bool CanShoot() {
        print(t);
        return HasEnoughAmmo() && t >= cooldown;
    }

    private bool HasEnoughAmmo() {
        return true; // TODO implement
    }
}

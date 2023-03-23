using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Transform GunTransform;
    [SerializeField]
    Transform normalWeaponPosition;
    [SerializeField]
    Transform aimPosition;

    [SerializeField]
    float animationSpeed = 4;
    float normalFOV = 60;
    float aimFOV = 8;
    void Start()
    {
        print(normalWeaponPosition.localPosition);
        GunTransform.localPosition = normalWeaponPosition.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")) {
            GunTransform.position = Vector3.Lerp(GunTransform.position, aimPosition.position, animationSpeed * Time.deltaTime);
            GunTransform.rotation = aimPosition.rotation;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, aimFOV, animationSpeed * Time.deltaTime);
        } else {
            GunTransform.position = Vector3.Lerp(GunTransform.position, normalWeaponPosition.position, animationSpeed * Time.deltaTime);
            GunTransform.rotation = normalWeaponPosition.rotation;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, animationSpeed * Time.deltaTime);
        }
    }

}

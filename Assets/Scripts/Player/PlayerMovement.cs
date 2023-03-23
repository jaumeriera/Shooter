using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float sprintBoost = 8f;

    [SerializeField] BoolVariable isRunnung;
    [SerializeField] GameEvent running;
    [SerializeField] GameEvent startStaminaRegeneration;


    float currentSpeed;
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * xMove + transform.forward * zMove;

        if (Input.GetButton("Run")) {
            controller.Move(move * (speed + sprintBoost) * Time.deltaTime);
            isRunnung.Value = true;
            running.Raise();
        } else {
            if (isRunnung.Value) {
                isRunnung.Value = false;
                startStaminaRegeneration.Raise();
            }
            controller.Move(move * speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerMovementVertical: MonoBehaviour
{
    [SerializeField] 
    CharacterController controller;
    [SerializeField]
    GameEvent jumping;
    [SerializeField]
    GameEvent startStaminaRegeneration;

    [SerializeField] 
    Transform groundCheck;
    [SerializeField] 
    float groundDistance = 0.4f;
    [SerializeField] 
    LayerMask groundMask;

    [SerializeField]
    float jumpHeight = 3f;
    [SerializeField]
    float gravity = -9.81f;
    Vector3 velocity;
    [SerializeField]
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        if (!isGrounded && IsTouchingTheGround()) {
            startStaminaRegeneration.Raise();
        }
        isGrounded = IsTouchingTheGround();

        ReduceVerticalSpeed();

        if (MustPerformJump()) {
            Jump();
        }

        Fall();
        controller.Move(velocity * Time.deltaTime);
    }

    private bool IsTouchingTheGround() {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void ReduceVerticalSpeed() {
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
    }

    private bool MustPerformJump() {
        return Input.GetButtonDown("Jump") && isGrounded;
    }

    private void Jump() {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        jumping.Raise();
    }

    private void Fall() {
        velocity.y += gravity * Time.deltaTime;
    }
}

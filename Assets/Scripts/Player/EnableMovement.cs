using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMovement : MonoBehaviour
{
    [SerializeField]
    PlayerMovement PM;
    [SerializeField]
    PlayerMovementVertical PMV;
    [SerializeField]
    Shoot S;
    [SerializeField]
    Magazine M;

    private void Start() {
        PM.enabled = false;
        PMV.enabled = false;
        S.enabled = false;
        M.enabled = false;
    }

    public void PlayerFree() {
        PM.enabled = true;
        PMV.enabled = true;
        S.enabled = true;
        M.enabled = true;
    }
}

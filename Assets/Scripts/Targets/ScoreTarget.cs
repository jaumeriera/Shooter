using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    [SerializeField]
    GameEvent scoreTarget;
    private void OnDisable() {
        scoreTarget.Raise();
    }
}

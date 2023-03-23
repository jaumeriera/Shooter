using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitialCountdown : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    GameEvent startGame;

    private void Start() {
    }

    public void EndCountdown() {
        StartCoroutine(DoEndCountdown());
    }

    private IEnumerator DoEndCountdown() {
        text.SetText("Go!");
        yield return new WaitForSeconds(1);
        startGame.Raise();
        gameObject.SetActive(false);
    }
}

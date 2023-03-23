using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    GameEvent endOfCountdown;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    int countdownTime;
    [SerializeField]
    bool initOnStart;

    void Start()
    {
        text.SetText(countdownTime.ToString());
        if (initOnStart) {
            StartCountDown();
        }
    }

    public void StartCountDown() {
        StartCoroutine(DoStartCountdown());
    }

    private IEnumerator DoStartCountdown() {
        while(countdownTime > 0) {
            yield return new WaitForSeconds(1);
            countdownTime -= 1;
            text.SetText(countdownTime.ToString());
        }
        endOfCountdown.Raise();
    }
}

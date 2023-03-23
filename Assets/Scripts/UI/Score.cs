using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    int scorePerTarget = 50;

    [SerializeField]
    FloatVariable currentScore;

    private void Start() {
        currentScore.Value = 0;
    }

    public void UpdateScore() {
        currentScore.Value += scorePerTarget;
        scoreText.SetText(currentScore.Value.ToString());
    }
}

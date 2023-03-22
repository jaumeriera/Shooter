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

    int currentScore = 0;

    public void UpdateScore() {
        currentScore += scorePerTarget;
        scoreText.SetText(currentScore.ToString());
    }
}

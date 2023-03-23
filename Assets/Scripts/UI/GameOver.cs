using FeTo.SOArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject HUD;
    [SerializeField]
    GameObject gameOverInfo;
    [SerializeField]
    TextMeshProUGUI scoreInfo;
    [SerializeField]
    FloatVariable score;

    private void Start() {
        gameOverInfo.SetActive(false);
    }

    public void DisplayGameOver() {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        HUD.SetActive(false);
        gameOverInfo.SetActive(true);
        scoreInfo.SetText("You get " + score.Value + " points, would you like to try again?");
    }
}

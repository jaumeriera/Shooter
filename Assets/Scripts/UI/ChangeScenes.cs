using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // 0 Main menu
    // 1 Gameplay

    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Gameplay() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

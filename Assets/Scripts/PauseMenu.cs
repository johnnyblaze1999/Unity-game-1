using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    // To keep the currentscore from counting
    public static bool isPaused = false;

    public void Pause(){
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume(){
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart(){
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Game");
    }

    public void ExitGame(){
        Application.Quit();
    }
}

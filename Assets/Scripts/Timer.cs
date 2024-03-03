using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;    
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }// If player remains alive, they win and time is stop
            else if(timeRemaining < 0)
            {
                timeIsRunning = false;
                SceneManager.LoadScene("gameWin");
            }
        }

    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt (timeToDisplay % 60);
        timeText.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public TMP_Text BestScoreText;
    private int bestScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        BestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = CurrentScore.score;
        if (currentScore > bestScore){
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            BestScoreText.text = "Best Score: " + bestScore.ToString();
        }
        
    }
}

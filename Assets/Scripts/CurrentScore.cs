using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    public TMP_Text pointText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pointText.text = score.ToString();
        StartCoroutine(IncrementPoint());
    }

    IEnumerator IncrementPoint(){
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            score++;
            pointText.text = score.ToString();
        }
    }
    // Update is called once per frame
    void Update(){
    }
}

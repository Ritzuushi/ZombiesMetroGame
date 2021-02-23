using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text highScoreText;

    // Update is called once per frame
    void Update()
    {
        int score = PlayerPrefs.GetInt("Score");
        int highScore = PlayerPrefs.GetInt("HighScore");
        
        highScoreText.text = "Highscore: " + highScore.ToString("0");
        
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public bool gameOver = false;
    public bool gamePaused = false;
    public float gameDifficulty;
    public int gameScore;
    public float gameTime;
    public int difficulty;
    public int isArmyGuy;
    public string kalisod;

    public TimerScript timeScript;
    public playerStatusScript statScript;
    public playerPrefs playerPrefs;
    public sceneManager sceneManager;
    public playerStatusScript stats;

    public Animator playAgain;

    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject hearts;
    public GameObject timer;
    public GameObject joystick;
    public GameObject pauseBtn;

    public Text gocTime;
    public Text gocMultiply;
    public Text gocAddCurrency;

    float playerHealth;
    public int currencyCalculation;

    void Awake() 
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
    }
    
    // Update is called once per frame
    void Update()
    { 
        isArmyGuy = PlayerPrefs.GetInt("isArmyGuy");

        if (difficulty == 1)
        {
            gameDifficulty = 1f;
            kalisod = gameDifficulty.ToString("0");
        }
        if (difficulty == 2)
        {
            gameDifficulty = 1.25f;
            kalisod = gameDifficulty.ToString("F2");
        }
        if (difficulty == 3)
        {
            gameDifficulty = 1.5f;
            kalisod = gameDifficulty.ToString("F1");
        }

        if (gamePaused == false)
        {
            gameTime = timeScript.gameTimer;
        }
        else if (gamePaused == true)
        {

        }
        
        playerHealth = statScript.playerHealth;
        currencyCalculation = (int)Math.Round(gameTime * gameDifficulty);
        string gocTimeText = gameTime.ToString("0");
        
        gocTime.text = gocTimeText;
        gocMultiply.text = gocTimeText + " x " + kalisod;
        gocAddCurrency.text = currencyCalculation.ToString("0");
        PlayerPrefs.SetInt("Score", currencyCalculation);
        gameScore = PlayerPrefs.GetInt("Score");
        if (playerHealth <= 0) {
            GameOver();
        } 
        
    }

    void OnDisable()
    {
        if (gameScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", gameScore);

            CloudOnceServices.instance.SubmitScore(PlayerPrefs.GetInt("HighScore"));
        }
        if (PlayerPrefs.GetInt("HighScore") >= 1000)
        {
            CloudOnceServices.instance.AchievementOne();
        }
        if (PlayerPrefs.GetInt("HighScore") >= 2500)
        {
            CloudOnceServices.instance.AchievementTwo();
        }
        if (PlayerPrefs.GetInt("HighScore") >= 5000)
        {
            CloudOnceServices.instance.AchievementThree();
        }

        if (gameTime <= 10)
        {
            CloudOnceServices.instance.TimeOne();
        }
        else if (gameTime <= 30)
        {
            CloudOnceServices.instance.TimeTwo();
        }
        else if (gameTime <= 60)
        {
            CloudOnceServices.instance.TimeThree();
        }
        else if (gameTime >= 300)
        {
            CloudOnceServices.instance.TimeFour();
        }

        if (PlayerPrefs.GetInt("Money") >= 5000)
        {
            CloudOnceServices.instance.MoneyTwo();
        }
    }

    public void Pause() 
    {
        gamePaused = true;
    }
    
    public void Resume() 
    {
        gamePaused = false;
    }

    public void Revive(float ToAdd) 
    {
        playerHealth += ToAdd;

        if (isArmyGuy == 1)
        {
            playerHealth += 20;
        }
    }

    public void Heal(float ToAdd)
    {
        playerHealth += ToAdd;
        if (isArmyGuy == 0 && playerHealth >= 30)
        {
            playerHealth = 30;
        }
        else if (playerHealth >= 50 && isArmyGuy == 1)
        {
            playerHealth = 50;
        }
    }

    public void LeaveGameOver()
    {
        playerPrefs.AddMoney(currencyCalculation);
        playerPrefs.AddPlays(1);
        
        playAgain.SetBool("hasRevived", false);
        gameOverScreen.SetActive(false);
        hearts.SetActive(true);
        timer.SetActive(true);
        joystick.SetActive(true);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;     
        sceneManager.EnterMenu();
    }

    void ContinueGame()
    {
        gameOverScreen.SetActive(false);
        hearts.SetActive(true);
        timer.SetActive(true);
        joystick.SetActive(true);
        pauseBtn.SetActive(true);  
    }

    void GameOver() 
    {
        gameOverScreen.SetActive(true);
        hearts.SetActive(false);
        timer.SetActive(false);
        joystick.SetActive(false);
        pauseBtn.SetActive(false);
    }



}


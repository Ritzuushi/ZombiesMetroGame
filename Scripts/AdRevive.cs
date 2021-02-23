using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdRevive : MonoBehaviour
{
    public playerStatusScript stats;
    public Rewarded ads;
    public enemySpawnerScript enemySpawns;
    public playerPrefs playerPrefs;
    public objectPooler objPool;
    public ScoreScript score;
    public TimerScript timeScript;

    public GameObject player;
    public GameObject enemy;
    public GameObject gameOverScreen;
    public GameObject hearts;
    public GameObject timer;
    public GameObject joystick;
    public GameObject pauseBtn;
    
    public Image reviveButton;
    public Text reviveText;
    public Animator reviveAnimation;
    public Sprite playAgain;

    float reviveHealth;
    int currency;
    int gameScore;
    float gameTime;

    public bool alreadyRevived = false;
    
    void Start() 
    {
        
    }

    void Update()
    {
        if (alreadyRevived == true)
        {
            reviveText.text = "Play Again";
            reviveButton.sprite = playAgain;
        }
        currency = score.currencyCalculation;
        gameScore = currency;
        gameTime = score.gameTime;
    }

    public void RewardedAd()
    {
        if(alreadyRevived == false) {
            ads.ShowRewardedAd();
            FindObjectOfType<SoundManager>().Pause("GameOver");
            reviveAnimation.SetBool("hasRevived", true);
        } 
        else 
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

            playerPrefs.AddMoney(currency);
            playerPrefs.AddPlays(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            FindObjectOfType<SoundManager>().Stop("GameOver");
            FindObjectOfType<SoundManager>().Play("Game");
            reviveAnimation.SetBool("hasRevived", false);
        }
    }

    public void ContinueGame()
    {
        gameOverScreen.SetActive(false);
        hearts.SetActive(true);
        timer.SetActive(true);
        joystick.SetActive(true);
        pauseBtn.SetActive(true);  
    }
}

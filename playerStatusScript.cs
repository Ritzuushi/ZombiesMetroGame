using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerStatusScript : MonoBehaviour
{   

    public playerPrefs playerPrefs;
    
    public float playerHealth;

    public int isArmyGuy;

    public Image heartOne;
    public Image heartTwo;
    public Image heartThree;
    public Image heartFour;
    public Image heartFive;

    public TimerScript timerScript;
    public screenOrientationScript screenShake;
    public objectPooler objPool;

    public GameObject player;
    
    float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = PlayerPrefs.GetFloat("Health");
    }

    // Update is called once per frame
    void Update()
    {
        isArmyGuy = PlayerPrefs.GetInt("isArmyGuy");

        if (playerHealth >= 50)
        {
            heartFive.fillAmount = 1f;
            heartFour.fillAmount = 1f;
            heartThree.fillAmount = 1f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        }
        else if (playerHealth >= 45)
        {
            
            heartFive.fillAmount = 0.5f;
            heartFour.fillAmount = 1f;
            heartThree.fillAmount = 1f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        }
        else if (playerHealth >= 40) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 1f;
            heartThree.fillAmount = 1f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        }
        else if (playerHealth >= 35) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0.5f;
            heartThree.fillAmount = 1f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        }
        else if (playerHealth >= 30) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 1f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        } else if (playerHealth >= 25) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 0.5f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        } else if (playerHealth >= 20) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 0f;
            heartTwo.fillAmount = 1f;
            heartOne.fillAmount = 1f;
        } else if (playerHealth >= 15) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 0f;
            heartTwo.fillAmount = 0.5f;
            heartOne.fillAmount = 1f;
        } else if (playerHealth >= 10) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 0f;
            heartTwo.fillAmount = 0f;
            heartOne.fillAmount = 1f;
        } else if (playerHealth >= 5) {
            heartFive.fillAmount = 0f;
            heartFour.fillAmount = 0f;
            heartThree.fillAmount = 0f;
            heartTwo.fillAmount = 0f;
            heartOne.fillAmount = 0.5f;
        } 
        if (playerHealth <= 0) {
            playerHealth = 0;
            heartOne.fillAmount = 0f;
            FindObjectOfType<SoundManager>().Stop("Run");
            FindObjectOfType<SoundManager>().Pause("Game");
            FindObjectOfType<SoundManager>().Play("GameOver");
            player.SetActive(false);
        }
    }

    public void Revive(float ToAdd) {
        
        playerHealth += ToAdd;

        if (isArmyGuy == 1)
        {
            playerHealth += 20;
        }
        
        FindObjectOfType<SoundManager>().Play("Game");
        FindObjectOfType<SoundManager>().Pause("GameOver");
        player.SetActive(true);
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

    public void TakeDamage (float damage)
    {
        StartCoroutine(screenShake.Shake(.1f, .2f));
        playerHealth -= damage;

    }

    void OnCollisionEnter2D(Collision2D colliderInfo)
    {   
        if (colliderInfo.collider.tag == "Enemy") {
            TakeDamage(2.5f);
            FindObjectOfType<SoundManager>().Play("TakeDamage");
        }
    }

    void OnCollisionStay2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Enemy") {
            TakeDamage(0.1f);
        }
    }

    public void MenuTransition()
    {
        FindObjectOfType<SoundManager>().Play("MainMenuMusic");
        FindObjectOfType<SoundManager>().Stop("Game");
        FindObjectOfType<SoundManager>().Stop("GameOver");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefs : MonoBehaviour
{
    public static playerPrefs Instance;

    public int money;
    
    public int totalPlays;

    public bool inGame = false;

    public int isArmyGuy;

    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } 
        else if (Instance != this) 
        {
            Destroy(gameObject);
        }
        #endregion 
        
        Screen.SetResolution(1920, 1080, true);
        
        money = PlayerPrefs.GetInt("Money");
        totalPlays = PlayerPrefs.GetInt("Plays");
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Plays", totalPlays);
    }

    public void Start()
    {
        if (inGame == false)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
        }
    }

    public void Update()
    {
        if (inGame == false)
        {
            if (isArmyGuy == 1)
            {
                PlayerPrefs.SetFloat("Health", 50);
            }
            if (isArmyGuy == 0)
            {
                PlayerPrefs.SetFloat("Health", 30);
            }
        }

        isArmyGuy = PlayerPrefs.GetInt("isArmyGuy");
    }

    public void AddMoney(int toAdd) 
    {
        PlayerPrefs.SetInt("Money", money += toAdd);
    }

    public void RemoveMoney(int toRemove)
    {
        PlayerPrefs.SetInt("Money", money -+ toRemove);
    }

    public void AddPlays(int toAdd)
    {
        PlayerPrefs.SetInt("Plays", totalPlays += toAdd);
    }

    public void StartGame()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocks : MonoBehaviour
{
    public GameObject purchaseMenu;

    public playerPrefs prefs;

    public int whichChoice;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPurchaseMenu()
    {
        if (whichChoice == 1 && PlayerPrefs.GetInt("UnlockedTwo") == 0)
        {
            purchaseMenu.SetActive(true);
        }
        if (whichChoice == 2 && PlayerPrefs.GetInt("UnlockedOne") == 0)
        {
            purchaseMenu.SetActive(true);
        }
    }
    
    public void ClosePurchaseMenu()
    {
        purchaseMenu.SetActive(false);
    }

    public void ChoiceOne()
    {
        whichChoice = 1;
    }

    public void ChoiceTwo()
    {
        whichChoice = 2;
    }

    public void Unlock()
    {
        if(whichChoice == 1)
        { 
            if (PlayerPrefs.GetInt("Money") < 1500)
            {
                FindObjectOfType<SoundManager>().Play("No");
            }
            else if (PlayerPrefs.GetInt("Money") >= 1500)
            {
                PlayerPrefs.SetInt("UnlockedTwo", 1);
                prefs.RemoveMoney(1500);
                FindObjectOfType<SoundManager>().Play("Buy");
                CloudOnceServices.instance.MoneyOne();
            }
        }
        if(whichChoice == 2)
        {
            if (PlayerPrefs.GetInt("Money") < 1500)
            {
                FindObjectOfType<SoundManager>().Play("No");
            }
            else if (PlayerPrefs.GetInt("Money") >= 1500)
            {
                PlayerPrefs.SetInt("UnlockedOne", 1);
                prefs.RemoveMoney(1500);
                FindObjectOfType<SoundManager>().Play("Buy");
                CloudOnceServices.instance.MoneyOne();
            }
            
        }
    }
}

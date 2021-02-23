using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public Image character;
    public Image characterTwo;
    public Image characterThree;

    public Sprite charOne;
    public Sprite charTwo;
    public Sprite charThree;
    public Sprite charTwoLocked;
    public Sprite charThreeLocked;

    public Text hearts;
    public Text speed;

    public int person;

    public int isUnlockedOne;
    public int isUnlockedTwo;

    public GameObject scrollbar;
    float scrollPos = 0;
    float[]pos;

    void Awake()
    {
        //PlayerPrefs.SetInt("UnlockedOne", 0);
        //PlayerPrefs.SetInt("UnlockedTwo", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        scrollPos = scrollbar.GetComponent<Scrollbar>().value;

        person = PlayerPrefs.GetInt("Character");

        if (person == 3) 
        {
            character.sprite = charOne;
            scrollPos = 0.9f;
        }
        else if (person == 2)
        {
            character.sprite = charTwo;
            scrollPos = 0.5f;
        }
        else if (person == 1)
        {
            character.sprite = charThree;
            scrollPos = 0.1f;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
        isUnlockedOne = PlayerPrefs.GetInt("UnlockedOne");
        isUnlockedTwo = PlayerPrefs.GetInt("UnlockedTwo");

        if (scrollPos  > 0.7) 
        {
            if (isUnlockedOne == 1)
            {
                character.sprite = charOne;
                characterThree.sprite = charOne;
                PlayerPrefs.SetInt("Character", 3);
                PlayerPrefs.SetInt("isArmyGuy", 1);
                hearts.text = "5";
                speed.text = "5";
            }
            else 
            {
                character.sprite = charThreeLocked;
                characterThree.sprite = charThreeLocked;
                PlayerPrefs.SetInt("Character", 1);
                hearts.text = "5";
                speed.text = "5";
            }
           
        }
        else if (scrollPos > 0.3)
        {
            if (isUnlockedTwo == 1)
            {
                character.sprite = charTwo;
                characterTwo.sprite = charTwo;
                PlayerPrefs.SetInt("Character", 2);
                PlayerPrefs.SetInt("isArmyGuy", 0);
                hearts.text = "3";
                speed.text = "7";
            }
            else
            {
                character.sprite = charTwoLocked;
                characterTwo.sprite = charTwoLocked;
                PlayerPrefs.SetInt("Character", 1);
                PlayerPrefs.SetInt("isArmyGuy", 0);
                hearts.text = "3";
                speed.text = "7";
            }
            
        }
        else if (scrollPos <= 0.3)
        {
            character.sprite = charThree;
            PlayerPrefs.SetInt("Character", 1);
            PlayerPrefs.SetInt("isArmyGuy", 0);
            hearts.text = "3";
            speed.text = "5";
        }
    
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if(scrollPos < pos[i] + (distance/2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp (scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
            {
                if(scrollPos < pos[i] + (distance/2) && scrollPos > pos[i] - (distance / 2))
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f,1f), 0.1f);
                    for (int a = 0; a < pos.Length; a++)
                    {
                        if (a != i)
                        {
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        }
                    }
                }
            }
    }
}

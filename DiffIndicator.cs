using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffIndicator : MonoBehaviour
{
    public DifficultyScript diff;

    public Text mmDiffText;
    public Text oDiffText;

    string diffText;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 1)
        {
            diffText = "Normal";
        }
        else if (difficulty == 2)
        {
            diffText = "Hard";
        }
        else if (difficulty == 3)
        {
            diffText = "Insane";
        }

        mmDiffText.text = "Difficulty: " + diffText;
        oDiffText.text = diffText;
    }
}

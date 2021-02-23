using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    private int difficulty = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficultyNormal()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty = 1);
    }
    public void SetDifficultyHard()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty = 2);
    }
    public void SetDifficultyInsane()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty = 3);
    }
}

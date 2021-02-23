using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public sceneManager sceneManager;
    public ScoreScript score;

    public GameObject pauseMenu;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause() 
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(true);
        score.Pause();
        FindObjectOfType<SoundManager>().Pause("Game");
        FindObjectOfType<SoundManager>().Stop("Run");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(false);
        score.Resume();
        FindObjectOfType<SoundManager>().Play("Game");
        Time.timeScale = 1f;  
    }

    public void LeaveGame()
    {
        isPaused = !isPaused;
        Time.timeScale = 1f;
        FindObjectOfType<SoundManager>().Stop("Run");
        sceneManager.EnterMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public Banner ads;

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<SoundManager>().Play("Game");
        FindObjectOfType<SoundManager>().Stop("MainMenuMusic");
    }

    public void EnterMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

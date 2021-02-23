using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;

    public float gameTimer;
    public float pauseTimer;
    public bool timerActive = true;
    public bool introDone;

    public playerStatusScript playerStatsScript;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        introDone = false;
    }

    // Update is called once per frame
    void Update()
    {   
        animator.SetBool("IntroDone", introDone);
        StartCoroutine(Timer());
        
        timerText.text = gameTimer.ToString("0");
    }

    IEnumerator Timer()    
    {
        float playerHealth = playerStatsScript.playerHealth;
        
        introDone = true;

        if (playerHealth <= 0) {
            timerActive = false;
        }
        
        if (timerActive == true) {
            
            yield return new WaitForSeconds(2f);
        
            gameTimer += Time.deltaTime;
        }
        
    }

    public void Revive()
    {
        timerActive = true;
    }

    public void Pause()
    {
        timerActive = false;
    }

    public void Resume()
    {
        timerActive = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;

    private void Awake()
    {
        TestSingleton();
    }

    private void TestSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScore(int score)
    {
        Leaderboards.HighScores.SubmitScore(score);
    }

    public void AchievementOne()
    {
        Achievements.One.Unlock();
    }
    public void AchievementTwo()
    {
        Achievements.Two.Unlock();
    }
    public void AchievementThree()
    {
        Achievements.Three.Unlock();
    }
    public void TimeOne()
    {
        Achievements.TimeOne.Unlock();
    }
    public void TimeTwo()
    {
        Achievements.TimeTwo.Unlock();
    }
    public void TimeThree()
    {
        Achievements.TimeThree.Unlock();
    }
    public void TimeFour()
    {
        Achievements.TimeFour.Unlock();
    }
    public void MoneyOne()
    {
        Achievements.MoneyOne.Unlock();
    }
    public void MoneyTwo()
    {
        Achievements.MoneyTwo.Unlock();
    }
}

using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Common;

public class Rewarded : MonoBehaviour
{
    RewardedAd rewardAd;
    public objectPooler objPool;
    public AdRevive adRev;
    public playerStatusScript stats;
    public ScoreScript score;
    public TimerScript timeScript;

    private string rewardId; // = "ca-app-pub-8431797750999762/7881566664";

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedAd();
    }

    //make button interactable if video ad is ready
    /*void Update()
    {
        if (rewardAd.IsLoaded())
        {
            watchAd.interactable = true;
        }
    }*/

    void RequestRewardedAd()
    {
#if UNITY_ANDROID
        rewardId = "ca-app-pub-3940256099942544/5224354917";
#else
        rewardId = null;
#endif
        rewardAd = new RewardedAd(rewardId);

        //call events
        rewardAd.OnAdLoaded += HandleRewardAdLoaded;
        rewardAd.OnAdFailedToLoad += HandleRewardAdFailedToLoad;
        rewardAd.OnAdOpening += HandleRewardAdOpening;
        rewardAd.OnAdFailedToShow += HandleRewardAdFailedToShow;
        rewardAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardAd.OnAdClosed += HandleRewardAdClosed;


        //create and ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            rewardAd.LoadAd(request); //load & show the banner ad
        }
        else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            rewardAd.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }

    //attach to a button that plays ad if ready
    public void ShowRewardedAd()
    {
        if (rewardAd.IsLoaded())
        {
            rewardAd.Show();
        }
    }

    //call events
    public void HandleRewardAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleRewardAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        //do this when ad fails to loads
        Debug.Log("Ad failed to load" + args.Message);
    }

    public void HandleRewardAdOpening(object sender, EventArgs args)
    {
        //do this when ad is opening
    }

    public void HandleRewardAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        //do this when ad fails to show
    }

    public void HandleUserEarnedReward(object sender, EventArgs args)
    {
        for(int i = 0; i < 200; i++)
        {
            objPool.DespawnToPool("Enemy");
        }
        adRev.ContinueGame();
        stats.Revive(30f);
        score.Revive(30f);
        timeScript.Revive();
        adRev.alreadyRevived = true;
    }

    public void HandleRewardAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
        RequestRewardedAd();
    }

}
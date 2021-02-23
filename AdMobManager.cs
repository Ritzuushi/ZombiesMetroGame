using System;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AdMobManager : MonoBehaviour
{

    private string bannerId = "ca-app-pub-8431797750999762/3261178266";
    private string interstitialId = "ca-app-pub-8431797750999762/5993963449";
    private string rewardId = "ca-app-pub-8431797750999762/7881566664";

    //private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    public playerPrefs prefs;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedAd();
        RequestInterstitial();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Plays") >= 20)
        {
            ShowInterstitial();
        }
    }

    // BannerAd
    /*public void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the bottom of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        //create and ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            bannerView.LoadAd(request); //load & show the banner ad
        }
        else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            bannerView.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }

    public void DesBanner()
    {
        bannerView.Destroy();
    } */

    // RewardedAd
    public void RequestRewardedAd()
    {
        #if UNITY_ANDROID
            rewardId = "ca-app-pub-3940256099942544/5224354917";
        #else
            rewardId = "unexpected_platform";
        #endif
            rewardedAd = new RewardedAd(rewardId);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardAdClosed;
        
        //create an ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            rewardedAd.LoadAd(request); //load & show the banner ad
        }
        else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            rewardedAd.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }

    //attach to a button that plays ad if ready
    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleUserEarnedReward(object sender, EventArgs args)
    {
        prefs.AddMoney(75);
        FindObjectOfType<SoundManager>().Play("Buy");
    }

    public void HandleRewardAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
        RequestRewardedAd();
    }

    // InterstitialAd
    void RequestInterstitial()
    {
        #if UNITY_ANDROID
            interstitialId = "ca-app-pub-3940256099942544/8691691433";
        #else
            interstitialId = "unexpected_platform";
        #endif
            interstitialAd = new InterstitialAd(interstitialId);
        
        //create an ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            interstitialAd.LoadAd(request); //load & show the banner ad
        }
        else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            interstitialAd.LoadAd(request); //load & show the banner ad (non-personalised)
        }

        interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitialAd.OnAdClosed += HandleOnAdClosed;
    }

    public void ShowInterstitial()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        PlayerPrefs.SetInt("Plays", 0);
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        PlayerPrefs.SetInt("Plays", 5);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
        PlayerPrefs.SetInt("Plays", 0);
    }
}

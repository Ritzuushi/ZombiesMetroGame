using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenOrientationScript : MonoBehaviour
{
    public GameObject ads;

    public Text adAddCurrency;

    public playerPrefs playerPrefs;
    public AdManager AdManager;

    void Awake()
    {

    }

    void Update()
    {
        adAddCurrency.text = PlayerPrefs.GetInt("Money").ToString();;
    }

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void RewardedAd()
    {
        AdManager.ShowRewardedAd(SuccessCoins, Skip, Failed);
        FindObjectOfType<SoundManager>().Pause("MainMenuMusic");
    }

    public void StandardAd()
    {
        AdManager.ShowStandardAd();
        FindObjectOfType<SoundManager>().Pause("MainMenuMusic");
    }

    void SuccessCoins()
    {
        playerPrefs.AddMoney(50);
        FindObjectOfType<SoundManager>().Play("MainMenuMusic");
    }

    void Skip()
    {
        Debug.Log("Ad Skipped");
        FindObjectOfType<SoundManager>().Play("MainMenuMusic");
    }

    void Failed()
    {
        Debug.Log("Ad Failed");
        FindObjectOfType<SoundManager>().Play("MainMenuMusic");
    }

}

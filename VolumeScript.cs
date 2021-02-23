﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("Volume") == 0)
        {
            PlayerPrefs.SetFloat("Volume", 1f);
        }
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);  
    }
}

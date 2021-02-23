using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickOptions : MonoBehaviour
{
    int joyPos;

    public Text joyPosText;

    // Start is called before the first frame update
    void Start()
    {
        joyPos = PlayerPrefs.GetInt("Joypos");

        if (joyPos == 0)
        {
            PlayerPrefs.SetInt("Joypos", 1);
        } 
        else
        {
            PlayerPrefs.SetInt("Joypos", joyPos);
        }
    }

    public void JoyPosLeft()
    {
        PlayerPrefs.SetInt("Joypos", 1);
        joyPosText.text = "Left";
    }

    public void JoyPosRight()
    {
        PlayerPrefs.SetInt("Joypos", 2);
        joyPosText.text = "Right";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Sfx", 1);
    }
    public void SoundFXButton()
    {
        if(PlayerPrefs.GetInt("Sfx") == 1)
        {
            PlayerPrefs.SetInt("Sfx", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Sfx", 1);
        }
    }
}

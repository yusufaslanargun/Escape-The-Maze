using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private Text soundText;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("soundEffects"))
        {
            PlayerPrefs.SetInt("soundEffects", 1);
            soundText.text = "On";
        }
        else
        {
            soundText.text = PlayerPrefs.GetInt("soundEffects") == 1 ? "On" : "Off";
        }
    }

    public void SoundButton()
    {
        if (PlayerPrefs.GetInt("soundEffects") == 0)
        {
            PlayerPrefs.SetInt("soundEffects", 1);
            soundText.text = "On";
        }
        else
        {
            PlayerPrefs.SetInt("soundEffects", 0);
            soundText.text = "Off";
        }
    }
}

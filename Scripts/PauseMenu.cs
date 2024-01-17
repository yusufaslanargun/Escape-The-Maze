using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Text soundText;
    void Awake()
    {
        gameObject.SetActive(false);
        soundText.text = PlayerPrefs.GetInt("soundEffects") == 1 ? "On" : "Off";
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

    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}

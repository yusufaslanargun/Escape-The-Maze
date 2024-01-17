using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("levelCompleted") || PlayerPrefs.GetInt("levelCompleted") < 0)
        {
            PlayerPrefs.SetInt("levelCompleted", 0);
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

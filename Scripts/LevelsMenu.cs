using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField]
    Button[] levelButtons;
    [SerializeField]
    Button[] increaseLevel, resetLevel;

    private void Start()
    {
        for (int i = PlayerPrefs.GetInt("levelCompleted") + 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }

    public void IncreaseLevel()
    {
        PlayerPrefs.SetInt("levelCompleted", PlayerPrefs.GetInt("levelCompleted") + 1);
        for(int i = 0; i <= PlayerPrefs.GetInt("levelCompleted"); i++)
        {
            levelButtons[i].interactable = true;
        }
        for (int i = PlayerPrefs.GetInt("levelCompleted") + 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("levelCompleted", 0);
        for (int i = 0; i <= PlayerPrefs.GetInt("levelCompleted"); i++)
        {
            levelButtons[i].interactable = true;
        }
        for (int i = PlayerPrefs.GetInt("levelCompleted") + 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }
}

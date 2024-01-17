using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private int levelNumber = 0;
    private AdManagerBanner admobReference;

    private void Awake()
    {
        admobReference = GameObject.FindObjectOfType<AdManagerBanner>();        
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(levelNumber + 1);
        admobReference.DestroyAd();
    }
}
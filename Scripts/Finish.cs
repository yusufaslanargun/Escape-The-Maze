using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool LevelCompleted = false;

    //[Header("Sound Effects")]
    //[SerializeField]
    //private AudioSource nextLevelSoundEffect;
    private AdManagerInterstitial adManager;

    private void Start()
    {
        adManager = GameObject.FindObjectOfType<AdManagerInterstitial>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player" && !LevelCompleted)
        {
            LevelCompleted = true;
            //if (PlayerPrefs.GetInt("soundEffects") == 1) nextLevelSoundEffect.Play();
            //adManager.ShowAd();
            Invoke("CompleteLevel", 1f);
            if(PlayerPrefs.GetInt("levelCompleted") < SceneManager.GetActiveScene().buildIndex - 1)
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

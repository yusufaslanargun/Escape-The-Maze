using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer inGameTimer;
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        inGameTimer.Disable();
        GameObject[] SkeletonsArray = GameObject.FindGameObjectsWithTag("Skeleton");
        for (int i = 0; i < SkeletonsArray.Length; i++)
        {
            SkeletonsArray[i].GetComponent<Animator>().Play("Idle");
            SkeletonsArray[i].GetComponent<NavMeshAgent>().enabled = false;
        }
        StartCoroutine(GameOverCoroutine());
        gameOverScreen.Setup();
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

}


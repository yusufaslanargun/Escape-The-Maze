using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Timer gameOverScreenTimer;
    public void Setup()
    {
        gameObject.SetActive(true);
        gameOverScreenTimer.Finish();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }*/

}

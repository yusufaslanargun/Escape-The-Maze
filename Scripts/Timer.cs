using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isFinished = false;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (isFinished)
        {
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
    }

    public void Disable()
    {
        isFinished = true;
        timerText.gameObject.SetActive(false);
    }

    public void Finish()
    {
        isFinished = true;
        timerText.color = Color.yellow;
    }
}

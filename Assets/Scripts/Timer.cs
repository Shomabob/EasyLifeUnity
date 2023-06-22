using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    public Text timerText;
    private int delta = 0;
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button stopButton;
    public Text timeText;
    private float startTime;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        stopButton.onClick.AddListener(OnStopButtonClick);
        StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void OnStartButtonClick()
    {
        startButton.gameObject.SetActive(false);
        stopButton.gameObject.SetActive(true);

        delta = 1; // начать отсчет таймера
        startTime = Time.time;
    }

    public void OnStopButtonClick()
    {
        startButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(false);

        delta = 0; // остановить таймер
    }

    public void OnUpdateTextButtonClick()
    {
        float elapsedTime = Time.time - startTime;
        string currentTime = (min + Mathf.FloorToInt(elapsedTime / 60)).ToString("D2") + " : " + ((sec + Mathf.FloorToInt(elapsedTime % 60)) % 60).ToString("D2");
        timeText.text = currentTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldChill : MonoBehaviour
{
    public InputField minutesInputField;
    public InputField secondsInputField;
    public Text timerText;
    public Button startButton;
    public Button resetButton;
    public Text formatText;

    private int totalSeconds = 0;
    private float timeLeft;
    private bool isTimerRunning = false;

    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            int minutes = int.Parse(minutesInputField.text);
            int seconds = int.Parse(secondsInputField.text);
            timeLeft = minutes * 60 + seconds;
            isTimerRunning = true;
            
        }
    }

    public void ResetTimer()
    {
        isTimerRunning = false;
        timeLeft = 0f;
        timerText.text = "00:00"; // Обнуляем текст таймера
        
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timeLeft -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);

            if (timeLeft <= 0)
            {
                minutes = 0;
                seconds = 0;
                isTimerRunning = false;
                startButton.interactable = true; // Разблокируем кнопку старта
                resetButton.interactable = false; // Блокируем кнопку сброса
            }

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void ConvertTimeToText()
    {
        int minutes = int.Parse(minutesInputField.text);
        int seconds = int.Parse(secondsInputField.text);

        // Суммируем текущее время со временем из прошлых вводов
        totalSeconds += (minutes * 60) + seconds;

        int displayMinutes = totalSeconds / 60;
        int displaySeconds = totalSeconds % 60;

        string formattedTime = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);

        formatText.text = formattedTime;
    }
}

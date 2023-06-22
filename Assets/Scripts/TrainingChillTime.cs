using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingChillTime : MonoBehaviour
{
    public Timer timer;
    public Text outputText;

    public void OnButtonClick()
    {
        // �������� ����� �� ������� � ��������� ��� �������� text � ���������� Text
        outputText.text = timer.timerText.text;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummReps : MonoBehaviour
{
    public InputField kgInputField;
    public InputField repetitionsInputField;
    public InputField minutesInputField;
    public InputField absrepsInputField;
    public Text resultText;

    private float totalKg = 0f;
    private int totalRepetitions = 0;
    private int TotalMin = 0;
    private int TotalAbs = 0;

    public void CalculateTotal()
    {
        // �������� �������� �� InputFields
        float kg = float.Parse(kgInputField.text);
        int repetitions = int.Parse(repetitionsInputField.text);

        // ��������� �������� � ������ ����������
        totalKg += kg;
        totalRepetitions += repetitions;

        // ���������� ��������� � Text
        resultText.text = "����� ���: " + totalKg.ToString() + " ��\n����� ���������� ����������: " + totalRepetitions.ToString();
    }

    public void CalculateMin()
    {
        int min = int.Parse(minutesInputField.text);

        TotalMin += min;
        resultText.text = "����� ������: " + TotalMin.ToString() + " �����";
    }

    public void CalculateReps()
    {
        int abs = int.Parse(absrepsInputField.text);

        TotalAbs += abs;
        resultText.text = "����� ���������� ����������: " + TotalAbs.ToString();
    }
}

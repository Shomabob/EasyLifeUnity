using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image[] slices;
    public Text[] labels;
    public float[] values;

    private float totalValue;

    void Start()
    {
        totalValue = 0f;
        for (int i = 0; i < values.Length; i++)
        {
            totalValue += values[i];
        }

        float currentAngle = -90f;
        for (int i = 0; i < slices.Length; i++)
        {
            float sliceValue = values[i] / totalValue;

            slices[i].fillAmount = sliceValue;
            slices[i].transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
            currentAngle -= sliceValue * 360f;

            labels[i].text = Mathf.RoundToInt(sliceValue * 100f).ToString() + "%";
        }
    }
}


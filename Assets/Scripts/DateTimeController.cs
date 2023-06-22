using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeController : MonoBehaviour
{
    public Button myButton;
    public Text myText;

    void Start()
    {
        myButton.onClick.AddListener(AddDateTime);
    }

    public void AddDateTime()
    {
        string dateTime = System.DateTime.Now.ToString();
        myText.text += dateTime + "\n";
    }
}
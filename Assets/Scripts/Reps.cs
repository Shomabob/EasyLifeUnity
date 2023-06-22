using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reps : MonoBehaviour
{
    public UnityEngine.UI.Button addButton;
    public Text minutes;
    public InputField inputFieldRun;
   

    void Start()
    {
        inputFieldRun.contentType = InputField.ContentType.IntegerNumber;    
        addButton.onClick.AddListener(AddinputFieldRun);
    }

    public void AddinputFieldRun()
    {
        string value = inputFieldRun.text;

        // Обновляем текст
        minutes.text = value + "/8";
    }

}



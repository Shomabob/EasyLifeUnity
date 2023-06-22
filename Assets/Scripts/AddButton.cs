using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    public Text text;

    private int count = 0;

    public void AddButtonClick()
    {
        count++;
        text.text = count.ToString() + "/4";
    }
}

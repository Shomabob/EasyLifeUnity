using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject toggle;
    public GameObject Panel;

    public void ToggleHide()
    {
        if (toggle.activeSelf == true) 
        { 
            toggle.SetActive(false); 
        } 
        else
        {
            toggle.SetActive(true);
        }            

    }

    public void BackButtonOn()
    {
        if(Panel != null) 
        {
           Panel.SetActive(false);
        }
    }
}

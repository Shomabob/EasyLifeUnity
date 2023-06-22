using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public ScrollRect ScrollRect;

    public void OnClick()
    {
        ScrollRect.enabled = true;
    }

}

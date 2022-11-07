using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_UI : MonoBehaviour
{
    public GameObject uiOpen, uiClose;

    public void OnMouseUpAsButton()
    {
        uiOpen.SetActive(true);
        uiClose.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public RectTransform panel;

    public void OpenSettings()
    {
        panel.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        panel.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game.");
    }
}

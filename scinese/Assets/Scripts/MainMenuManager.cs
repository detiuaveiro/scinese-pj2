using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public RectTransform panel;
    public GameObject[] objectsHide = new GameObject[4];

    public void OpenSettings()
    {
        for(int i = 0; i < objectsHide.Length; i++)
        {
            objectsHide[i].SetActive(false);
        }
        panel.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        for (int i = 0; i < objectsHide.Length; i++)
        {
            objectsHide[i].SetActive(true);
        }
        panel.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game.");
    }
}

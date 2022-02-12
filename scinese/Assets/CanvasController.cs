using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject dialoguebox;

    public void HideLoadingScreen()
    {
        loadingScreen.gameObject.SetActive(false);
    }
}

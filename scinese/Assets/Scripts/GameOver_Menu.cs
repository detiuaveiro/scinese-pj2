using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Menu : MonoBehaviour
{
    public static bool isGameOver = false; //public static para poder aceder atrav�s de outros scripts
    private CanvasGroup cvGameOver;

    private void Awake()
    {
        cvGameOver = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        cvGameOver.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if (isGameOver == true)
       {
           EndGame();
       }
    }

    public void EndGame()
    {
        cvGameOver.alpha = 1;
        cvGameOver.blocksRaycasts = false;
        // pauseMenu.SetActive(true);
        Time.timeScale = 0f; //Parar o tempo no jogo.
    }
}

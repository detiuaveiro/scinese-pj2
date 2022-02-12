using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Menu : MonoBehaviour
{
    public static bool isGameOver = false; //public static para poder aceder através de outros scripts
    private CanvasGroup cvGameOver;
    public GameObject inventory;

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

    public void LoadLevel(int sceneIndex) //método public para funcionar noutros scripts
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void EndGame()
    {
        cvGameOver.alpha = 1;
        cvGameOver.blocksRaycasts = true;
        // pauseMenu.SetActive(true);
        Time.timeScale = 0f; //Parar o tempo no jogo.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool isGamePaused = false; //public static para poder aceder através de outros scripts
    private CanvasGroup cvPauseMenu;

    private void Awake()
    {
        cvPauseMenu = GetComponent<CanvasGroup>();
        ResumeGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Esc para pause
        {
            if (isGamePaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        cvPauseMenu.alpha = 0;
        cvPauseMenu.blocksRaycasts = false;
        // pauseMenu.SetActive(false);
        Time.timeScale = 1f; //Continuar tempo no jogo
        isGamePaused = false;
    }

    private void PauseGame()
    {
        cvPauseMenu.alpha = 1;
        cvPauseMenu.blocksRaycasts = true;
        // pauseMenu.SetActive(true);
        Time.timeScale = 0f; //Parar o tempo no jogo.
        isGamePaused = true;
    }

    public void SettingsGame()
    {
        //Fazer outro panel para as settings
    }

    public void QuitGame()
    {
        Application.Quit();//Terminar jogo
        Debug.Log("The game is over."); //Verificar se está a funcionar
    }
}

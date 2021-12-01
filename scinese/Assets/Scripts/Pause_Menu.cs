using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool isGamePaused = false; //public static para poder aceder atrav�s de outros scripts
    public GameObject pauseMenu; //mesma forma de ter uma variavel que possa ser vista no inspector, por�m mais privada, pois s� pode ser acedida atrav�s deste script

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
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //Continuar tempo no jogo
        isGamePaused = false;
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
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
        Debug.Log("The game is over."); //Verificar se est� a funcionar
    }
}

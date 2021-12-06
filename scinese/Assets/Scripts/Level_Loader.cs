using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //mexer com os Ui objects(tipo botao, slider)

public class Level_Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public Button btSet;
    public Button btqt;

    public void LoadLevel(int sceneIndex) //método public para funcionar noutros scripts
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //ir de 0 para 1 no loading
            Debug.Log(progress);

            slider.gameObject.SetActive(true);//Ativar slider
            slider.value = progress;
            progressText.text = progress * 100f + "%"; 
            btSet.gameObject.SetActive(false);//Desativar button
            btqt.gameObject.SetActive(false);//Desativar button


            yield return null;
        }
    }
}

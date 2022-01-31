using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue : MonoBehaviour //Esta classe vai levar toda a informa��o de uma conversa
{
    public GameObject diag_box;
    public string name_npc; //nome do npc 
    public GameObject inventory;
    private bool nextSentence;

    [TextArea(3, 10)]
    public string[] sentences_diag; //frases para dar load no queue

    [SerializeField] public TextMeshProUGUI text_name;
    [SerializeField] public TextMeshProUGUI text_dialogue;
   // [SerializeField] public Animator anim;
    
   
    private Queue<string> sentences; //Queue, funciona como uma lista, utiliza o sistema first in first out
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        nextSentence = true;
    //    }
    //}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue() //
    {
        inventory.gameObject.SetActive(false);
        //anim.SetBool("IsShow", true);
        diag_box.SetActive(true);
        Time.timeScale = 0f; //Parar o tempo no jogo.

        text_name.text = name_npc;
        Debug.Log(name_npc);

        sentences.Clear(); //apagar frases de conversas antigas

        foreach (string sentence in sentences_diag) //Aceder as strings da classe dialogue
        {
            sentences.Enqueue(sentence); //p�r as frases em queue
            text_dialogue.text = sentence;
           // Debug.Log(sentence);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DisplayNextSentence();
        //}

         DisplayNextSentence();
    }

    public void DisplayNextSentence() //Buscar a pr�xima frase em queue
    {
        if (sentences.Count == 0) //Se n�o houver mais frases, terminar
        {
            //EndDialogue();
            Debug.Log("Finish Sentences");
            return;
        }

        string sentence = sentences.Dequeue(); //Se houver ainda frases, buscar a pr�xima
        text_dialogue.text = sentence;
        Debug.Log(sentence);
        StopAllCoroutines();//garantir que animamos o que o user quer
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)//Co-rotina para escrever cada um dos carateres
    {
        text_dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            text_dialogue.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        diag_box.SetActive(false);
        Time.timeScale = 1f; //Continuar tempo no jogo
        inventory.gameObject.SetActive(true);
        //anim.SetBool("IsShow", false);
    }
}

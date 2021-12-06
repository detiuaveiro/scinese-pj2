using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text nameText; //variavel da UI para aceder e alterar o texto
    public Text DialogueText;
    public Animator animator;

    private Queue<string> sentences; //Queue, funciona como uma lista, utiliza o sistema first in first out
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) //
    {
        animator.SetBool("IsShow", true);
        //Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear(); //apagar frases de conversas antigas

        foreach(string sentence in dialogue.sentences) //Aceder as strings da classe dialogue
        {
            sentences.Enqueue(sentence); //pôr as frases em queue
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //Buscar a próxima frase em queue
    {
        if(sentences.Count == 0) //Se não houver mais frases, terminar
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); //Se houver ainda frases, buscar a próxima
        //DialogueText.text = sentence;
        StopAllCoroutines();//garantir que animamos o que o user quer
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)//Co-rotina para escrever cada um dos carateres
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsShow", false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject DialogueManager;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue); //mandar o dialogo para o dialogue_manager. nota: fazer isto com singleton, forma mais correta
    }
}


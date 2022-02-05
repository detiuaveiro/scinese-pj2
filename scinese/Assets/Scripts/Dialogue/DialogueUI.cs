using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textlabel;

    public bool isOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypeWritterEffect typeWritterEffect;

    private void Start()
    {
        typeWritterEffect = GetComponent<TypeWritterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvents[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }


    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        //foreach (string dialogue in dialogueObject.Dialogue)
        //{
        //    yield return typeWritterEffect.Run(dialogue, textlabel);
        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        //}

        for(int i = 0; i< dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWritterEffect.Run(dialogue, textlabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}

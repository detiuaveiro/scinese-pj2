using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textlabel;
    [SerializeField] private TMP_Text textnamelabel;

    public bool isOpen { get; private set; }

    private Player player;
    private ResponseHandler responseHandler;
    private TypeWritterEffect typeWritterEffect;

    private void Start()
    {
        player = GameManager.instance.player;
        typeWritterEffect = GetComponent<TypeWritterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        player.rb.bodyType = RigidbodyType2D.Static;
        isOpen = true;
        dialogueBox.SetActive(true);
        textnamelabel.text = dialogueObject.Name;
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
            player.rb.bodyType = RigidbodyType2D.Dynamic;
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}

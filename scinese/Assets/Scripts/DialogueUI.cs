using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textlabel;

    public bool isOpen { get; private set; }

    private TypeWritterEffect typeWritterEffect;

    private void Start()
    {
        typeWritterEffect = GetComponent<TypeWritterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }


    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typeWritterEffect.Run(dialogue, textlabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}

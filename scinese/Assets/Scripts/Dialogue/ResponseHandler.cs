using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;
    private ResponseEvents[] responseEvents;

    private List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }

    public void AddResponseEvents(ResponseEvents[] responseEvents)
    {
        this.responseEvents = responseEvents;
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxWidht = 0;

        for(int i = 0; i< responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.Responsetext;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxWidht += responseButtonTemplate.sizeDelta.x;
        }

        responseBox.sizeDelta = new Vector2(responseBoxWidht, responseBox.sizeDelta.y);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response, int responseIndex)
    {
        responseBox.gameObject.SetActive(false);

        foreach(GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        if(responseEvents != null && responseIndex <= responseEvents.Length) 
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
            dialogueUI.CloseDialogueBox();
        }
        else
        {
            dialogueUI.ShowDialogue(response.DialogueObject);
        }  
    }
}

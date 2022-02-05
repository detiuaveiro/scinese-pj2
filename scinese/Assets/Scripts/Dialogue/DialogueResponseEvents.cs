using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueResponseEvents : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private ResponseEvents[] events;

    public ResponseEvents[] Events => events;

    public void OnValidate()
    {
        if (dialogueObject == null) return;
        if (dialogueObject.Responses == null) return;
        if (events != null && events.Length == dialogueObject.Responses.Length) return;

        if (events == null)
        {
            events = new ResponseEvents[dialogueObject.Responses.Length];
        }
        else
        {
            Array.Resize(ref events, dialogueObject.Responses.Length);
        }

        for (int i = 0; i < dialogueObject.Responses.Length; i++)
        {
            Response response = dialogueObject.Responses[i];

            if (events[i] != null)
            {
                events[i].name = response.Responsetext;
                continue;
            }

            events[i] = new ResponseEvents() { name = response.Responsetext };
        }
    }
}

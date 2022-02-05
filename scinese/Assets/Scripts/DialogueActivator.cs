using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    public GameObject ballon;
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ballon.SetActive(true);
        if(other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ballon.SetActive(false);
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(Player player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}

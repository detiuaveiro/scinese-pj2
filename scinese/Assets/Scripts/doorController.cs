using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public BoxCollider2D boxcollider;
    private Player player;
    public Item_Data key;


    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }


    public void OpenDoor()
    {
        if (!isOpen && player.inventory.items.Contains(key))
        {
            isOpen = true;
            Debug.Log("Door is Unlocked");//Destrancar porta
            animator.SetBool("isOpen", true); //ativar anima��o abrir porta
            boxcollider.enabled = false; //Desabilitar o collider para o player passar
            player.inventory.items.Remove(key);
        }
    }
}

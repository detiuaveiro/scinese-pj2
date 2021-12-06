using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public BoxCollider2D boxcollider;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Door is Unlocked");//Destrancar porta
            animator.SetBool("isOpen", true); //ativar animação abrir porta
            boxcollider.enabled = false; //Desabilitar o collider para o player passar
        }
    }
}

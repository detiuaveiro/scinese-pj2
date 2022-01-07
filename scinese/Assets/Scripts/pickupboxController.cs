using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupboxController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenBox()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Box is Unlocked");//Destrancar porta
            animator.SetBool("isPick", true); //ativar animação abrir bau
        }
    }
}

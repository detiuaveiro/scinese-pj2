using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversatio_Controller : MonoBehaviour
{
    public bool isShow;
    public Animator animator;

    public void ShowText()
    {
        if (!isShow)
        {
            isShow = true;
            animator.SetBool("isShow", true); //ativar animação abrir porta
        }
    }
}

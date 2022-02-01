using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public GameObject keyObject;
    public GameObject ballon;
    int key;
    public AudioSource sfx;

    public void OpenChest()
    {
        if (!isOpen)
        {
            sfx.Play();
            isOpen = true;
            Debug.Log("Chest is Unlocked");//Destrancar porta
            animator.SetBool("isOpen", true); //ativar animação abrir bau
            keyObject.gameObject.SetActive(true);//mostrar chave
            //ballon.gameObject.SetActive(true);//mostrar balao com interrogacao
        } 
        else {

            while(key < 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    key++;
                    //keyObject.gameObject.SetActive(false);
                    ballon.gameObject.SetActive(false);
                }
            }
        }
    }
}

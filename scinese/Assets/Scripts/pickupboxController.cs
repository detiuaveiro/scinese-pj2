using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupboxController : MonoBehaviour
{
    public bool isOpen;
    //public Animator animator;
    public GameObject pickaxe;
    public GameObject minimapcIcon;
    public GameObject interactable;

    private Player player;

    public void Start()
    {
        player = GameManager.instance.player;
    }

    public void OpenBox()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Box is Unlocked");//Destrancar porta
            player.anim.SetBool("isPick", true); //ativar anima��o abrir bau
            pickaxe.gameObject.SetActive(false);//desativar pickaxe
            minimapcIcon.gameObject.SetActive(false); //desativar icon no minimap
            interactable.gameObject.SetActive(false); //desativar interação, juntamente com o balao
        }
    }
}

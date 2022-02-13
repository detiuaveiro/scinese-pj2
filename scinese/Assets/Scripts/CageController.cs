using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CageController : MonoBehaviour
{
    public bool isOpen;
    public Animator animalAnim;
    public Animator cageAnim;
    public Item_Data key;
    public AudioSource sfx;
    private Player player;

    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    public void OpenCage()
    {
        if (!isOpen && player.inventory.items.Contains(key))
        {
            sfx.Play();
            isOpen = true;
            Debug.Log("Trapdoor is Unlocked");//Destrancar porta
            animalAnim.SetBool("disapear", true); //ativar animação abrir porta
            cageAnim.SetBool("isOpen", true);
            player.inventory.RemoveItem(key);
        }
    }
}
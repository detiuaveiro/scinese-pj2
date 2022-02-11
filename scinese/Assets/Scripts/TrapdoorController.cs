using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class TrapdoorController : MonoBehaviour
{
    public bool isOpen;
   // public Animator animator;
    //public BoxCollider2D boxcollider;
    private Player player;
    public Item_Data key;
    public AudioSource sfx;


    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    public void LoadLevel(int sceneIndex) //método public para funcionar noutros scripts
    {
        if (!isOpen && player.inventory.items.Contains(key))
        {
            sfx.Play();
            isOpen = true;
            Debug.Log("Trapdoor is Unlocked");//Destrancar porta
            //animator.SetBool("isOpen", true); //ativar animação abrir porta
            //boxcollider.enabled = false; //Desabilitar o collider para o player passar
            player.inventory.RemoveItem(key);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

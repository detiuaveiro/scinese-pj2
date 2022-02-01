using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatckKey : MonoBehaviour
{
    private Player player;

    public Item_Data item;
    public float amount;
    public GameObject infballon;
    public GameObject itemButton;
    public AudioClip sfx;

    public bool isInRange; //Variável para verificar se está no range
    public KeyCode InteractKey; //Variável para passar a tecla de interação

    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) //se o player estiver no range
        {
            if (Input.GetKeyDown(InteractKey)) //e pressionar a tecla "e"
            {
                for (int i = 0; i < player.inventory.items.Length; i++)
                {
                    if (player.inventory.isSlotFull[i] == false)
                    {
                        AudioSource.PlayClipAtPoint(sfx, transform.position);
                        player.inventory.AddItem(item);
                        player.inventory.isSlotFull[i] = true;
                        player.inventory.itemIn[i] = true;
                        Instantiate(itemButton, player.inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
              //  Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player estiver no range
        {
            isInRange = true;
            infballon.gameObject.SetActive(true);
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player não estiver no range
        {
            isInRange = false;
            infballon.gameObject.SetActive(false);
            Debug.Log("Player is not Range");
        }
    }
}

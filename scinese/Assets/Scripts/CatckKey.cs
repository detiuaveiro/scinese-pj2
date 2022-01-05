using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatckKey : MonoBehaviour
{
    private Player player;

    public Item_Data item;
    public float amount;

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
                player.inventory.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player estiver no range
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player não estiver no range
        {
            isInRange = false;
            Debug.Log("Player is not Range");
        }
    }
}

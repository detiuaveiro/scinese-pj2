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

    public bool isInRange; //Vari�vel para verificar se est� no range
    public KeyCode InteractKey; //Vari�vel para passar a tecla de intera��o

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
            infballon.gameObject.SetActive(true);
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player n�o estiver no range
        {
            isInRange = false;
            infballon.gameObject.SetActive(false);
            Debug.Log("Player is not Range");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    private Player player;

    public Item_Data item;
    public float amount;
    public GameObject itemButton;


    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        
            for (int i =0; i < player.slots.Length; i++)
            {
                if(player.inventory.isSlotFull[i] == false)
                {
                    player.inventory.isSlotFull[i] = true;
                    Instantiate(itemButton, player.inventory.slots[i].transform, false); //instanciado como filho do slot
                   
                    Debug.Log("Collided with an object!! KEKW");
                    player.inventory.AddItem(item);
                    Destroy(gameObject);
                break;
                }
            }


    }
}

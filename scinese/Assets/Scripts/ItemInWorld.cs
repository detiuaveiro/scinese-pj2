using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    private Player player;

    public Item_Data item;
    public float amount;
    public GameObject itemButton;
    public AudioClip sfx;


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
                AudioSource.PlayClipAtPoint(sfx, transform.position);
                    player.inventory.isSlotFull[i] = true;
                Debug.Log(itemButton);
                Debug.Log(player);
                    Instantiate(itemButton, player.inventory.slots[i].transform, false); //instanciado como filho do slot 

                    Debug.Log("Collided with an object!! KEKW");
                    player.inventory.AddItem(item);
                    Destroy(gameObject);
                break;
                }
            }
    }
}

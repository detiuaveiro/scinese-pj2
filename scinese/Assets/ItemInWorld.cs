using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    private Player player;

    public Item_Data item;
    public float amount;

    private void Start()
    {
        player = Player.instance; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Debug.Log("Collided with an object!! KEKW");
        player.inventory.AddItem(item);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractInv : MonoBehaviour
{ 
    private Player player;
    public GameObject item;

    private void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y + 3);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}

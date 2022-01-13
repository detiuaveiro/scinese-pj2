using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{

    private Player player;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItem();
        }

        if(transform.childCount <= 0)
        {
            player.inventory.isSlotFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UseItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

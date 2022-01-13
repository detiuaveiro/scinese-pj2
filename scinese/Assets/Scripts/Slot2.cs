using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot2 : MonoBehaviour
{



    public void DropItem()
    {
        foreach (Transform child in transform)
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

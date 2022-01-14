using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item_Data> items;
    private int maxSpace = 4;

    public GameObject[] slots;
    public bool[] isSlotFull;

    public Inventory(int maxSpace, GameObject[] slots, bool[] isSlotFull)
    {
        items = new List<Item_Data>();
        this.maxSpace = maxSpace;
        this.slots = slots;
        this.isSlotFull = isSlotFull;
    }

    public void AddItem(Item_Data newItem)
    {
        if (!this.isFull())
        {
            items.Add(newItem);
        }
    }

    public void RemoveItem(Item_Data item)
    {
        items.Remove(item);
    }

    public bool isFull()
    {
        if (items.Count >= maxSpace)
        {
            Debug.LogWarning("Full Inventory!!");
            return true;
        }
        return false;
    }

    public List<Item_Data> GetAllItems()
    {
        return items;
    }
}

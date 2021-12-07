using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item_Data> items;
    private int maxSpace;

    public Inventory(int maxSpace)
    {
        items = new List<Item_Data>();
        this.maxSpace = maxSpace;
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
}

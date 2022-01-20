using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Inventory
{
    //public List<Item_Data> items;
    public Item_Data[] items;

    private int maxSpace = 4;

    public GameObject[] slots;
    public bool[] isSlotFull;
    public bool[] itemIn;
    private SlotController slotController;


    public Inventory(int maxSpace, GameObject[] slots, bool[] isSlotFull)
    {
        //items = new List<Item_Data>();
        // this.items = new Item_Data[4];
        items = new Item_Data[4];
        itemIn = new bool[4];
        this.maxSpace = maxSpace;
        this.slots = slots;
        this.isSlotFull = isSlotFull;
    }

    public void AddItem(Item_Data newItem)
    {
        if (itemIn[0] == false )
        {
            itemIn[0] = true;
            items[0] = newItem;
        } else if (itemIn[1] == false)
        {
            itemIn[1] = true;
            items[1] = newItem;
        } else if (itemIn[2] == false)
        {
            itemIn[2] = true;
            items[2] = newItem;
        }else if (itemIn[3] == false)
        {
            itemIn[3] = true;
            items[3] = newItem;
        }
    }

    public void RemoveItem(Item_Data item)
    {
       List<Item_Data> itemList = items.ToList(); //transformar array em lista
       int index = itemList.FindIndex(c => c == item); //descobrir posição do item
        itemList[index] = null; //atribuir valor null a essa posição
        itemIn[index] = false; //atribuir à posição o valor de false na variável bool
        isSlotFull[index] = false; //atribuir à posição o valor de false na variável bool
        items = itemList.ToArray(); //voltar a converter em array

        foreach (Transform child in slots[index].transform) //aceder filhos do gameobject
        {
            GameObject.Destroy(child.gameObject); //destruir caso tenha filho
        }

    }
}


//    public void AddItem(Item_Data newItem)
//    {
//        if (!this.isFull())
//        {
//            items.Add(newItem);
//        }
//    }

//    public void RemoveItem(Item_Data item)
//    {
//        items.Remove(item);
//    }

//    public bool isFull()
//    {
//        if (items.Count >= maxSpace)
//        {
//            Debug.LogWarning("Full Inventory!!");
//            return true;
//        }
//        return false;
//    }

//    public List<Item_Data> GetAllItems()
//    {
//        return items;
//    }
//}

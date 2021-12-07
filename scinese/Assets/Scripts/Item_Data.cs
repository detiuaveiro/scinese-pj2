using UnityEngine;

[CreateAssetMenu(fileName ="new Item", menuName ="Inventory/Item")]
public class Item_Data : ScriptableObject
{
    public string itemName;
    public int amount;
    public Sprite spr;
    public bool isStacked;

    public virtual void UseItem()
    {
        Debug.Log("You just used " + itemName);
    }
}

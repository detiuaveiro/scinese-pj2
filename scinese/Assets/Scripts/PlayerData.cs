using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string level;
    public int health;
    public float[] position;
    public Inventory inventory;

    public PlayerData()
    {
        this.level = GameManager.instance.actualLevel;
        this.position = new float[3];
        position[0] = GameManager.instance.lastPosition.x;
        position[1] = GameManager.instance.lastPosition.y;
        this.health = GameManager.instance.health;
       // this.inventory.items = GameManager.instance.inventory.items;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string level;
    public int numberOfLives;
    public float[] position;

    public PlayerData()
    {
        this.level = GameManager.instance.actualLevel;
        this.position = new float[3];
        position[0] = GameManager.instance.lastPosition.x;
        position[1] = GameManager.instance.lastPosition.y;
    }
}

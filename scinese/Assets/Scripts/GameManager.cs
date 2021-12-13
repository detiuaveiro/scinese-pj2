using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Debug.LogWarning("instance already exists!");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // references
    public Player player;
    public Inventory inventory;

    // logic
    public int leaves;
    public int numberOfLives;
    public Vector2 lastCheckpoint;

    // methods to save the state of the game and to load the game

    public void SaveState()
    {
        Debug.Log("SaveState");
    }

    public void LoadState()
    {
        Debug.Log("LoadState");
    }
}

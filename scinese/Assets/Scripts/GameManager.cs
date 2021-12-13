using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
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
    public string actualLevel;
    public int leaves;
    public int numberOfLives;
    public Vector2 lastPosition;

    // methods to save the state of the game and to load the game

    public void SaveState()
    {
        actualLevel = SceneManager.GetActiveScene().name;
        lastPosition.x = player.transform.position.x; 
        lastPosition.y = player.transform.position.y;
    }

    public void LoadState()
    {
        Debug.Log("LoadState");
    }
}

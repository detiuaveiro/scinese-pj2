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
        this.LoadState();
    }

    // references
    public Player player;
    public Inventory inventory;
    public SaveSystem saveSystem;

    // logic
    public string actualLevel;
    public int leaves;
    public int numberOfLives;
    public Vector2 lastPosition;

    // methods to save the state of the game and to load the game

    public void SaveState()
    {   
        // setting the new values that will be stored
        actualLevel = SceneManager.GetActiveScene().name;
        lastPosition.x = player.transform.position.x; 
        lastPosition.y = player.transform.position.y;
        
        // saving the actual state of the game
        saveSystem.Save();
        Debug.Log("Game Saved! Thank you for your preference.");
    }

    public void LoadState()
    {
        PlayerData data = saveSystem.Load();
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(data.level))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(data.level));
        }
        // SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        
        player.gameObject.transform.position = new Vector2(data.position[0], data.position[1]);
    }
}

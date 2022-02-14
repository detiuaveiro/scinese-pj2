using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool[] hasloaded = new bool[4];

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
        /*if (saveSystem.ExistsData())
        {
            this.LoadState();
        }*/

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(camera);
        //DontDestroyOnLoad(levelLoader);
    }

    private void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        //fazer o mesmo para as restantes cenas, com a posiï¿½ï¿½o inicial no sï¿½tio certo

        if (!hasloaded[0] && sceneIndex == 2) // se a cena ativa for a 2 
        {
            hasloaded[0] = true;
           // player.transform.position = new Vector2(4.7f, 31.3f); //posiï¿½ï¿½o inicial do player
            player.transform.position = new Vector2(-10f, 13.34f);
            player.rb.bodyType = RigidbodyType2D.Dynamic; //rb dynamic para poder movimentar
            //canvasController.dialoguebox.SetActive(false); //desativar dialoguebox do canvas
            canvasController.loadingScreen.SetActive(false); //desativar loadingscreen do canvas
        }
        if (!hasloaded[1] && sceneIndex == 3) // se a cena ativa for a 3 
        {
            hasloaded[1] = true;
            player.transform.position = new Vector2(-23, 0); //posiï¿½ï¿½o inicial do player
            player.rb.bodyType = RigidbodyType2D.Dynamic; //rb dynamic para poder movimentar
            //canvasController.dialoguebox.SetActive(false); //desativar dialoguebox do canvas
            canvasController.loadingScreen.SetActive(false); //desativar loadingscreen do canvas
        }
        else if (!hasloaded[2] && sceneIndex == 4) // se a cena ativa for a 3 
        {
            hasloaded[2] = true;
            player.transform.position = new Vector2(-14.5f, 10f); //posiï¿½ï¿½o inicial do player
            player.rb.bodyType = RigidbodyType2D.Dynamic; //rb dynamic para poder movimentar
            //canvasController.dialoguebox.SetActive(false); //desativar dialoguebox do canvas
            canvasController.loadingScreen.SetActive(false); //desativar loadingscreen do canvas
        }
        if (player.isDead && sceneIndex == 2) // se a cena ativa for a 2
        {
            player.isDead = false;
            hasloaded[1] = false;
            hasloaded[2] = false;
            Time.timeScale = 1f;
            player.transform.position = new Vector2(4.7f, 31.3f); //posiï¿½ï¿½o inicial do player
            player.rb.bodyType = RigidbodyType2D.Dynamic; //rb dynamic para poder movimentar
            player.currentHealth = 10;
            player.healthBar.SetHealth(player.currentHealth);
            canvasController.gameoverBox.SetActive(false);
            //canvasController.dialoguebox.SetActive(false); //desativar dialoguebox do canvas
            canvasController.loadingScreen.SetActive(false); //desativar loadingscreen do canvas
        }

        if (player.hasWon && sceneIndex == 2) // se a cena ativa for a 2
        {
            player.hasWon = false;
            hasloaded[1] = false;
            hasloaded[2] = false;
            player.transform.position = new Vector2(4.7f, 31.3f); //posição inicial do player
            player.rb.bodyType = RigidbodyType2D.Dynamic; //rb dynamic para poder movimentar
            player.currentHealth = 10;
            player.healthBar.SetHealth(player.currentHealth);
            canvasController.gameoverBox.SetActive(false);
            //canvasController.dialoguebox.SetActive(false); //desativar dialoguebox do canvas
            canvasController.loadingScreen.SetActive(false); //desativar loadingscreen do canvas
        }
    }

    // references
    public Player player;
    public Inventory inventory;
    public SaveSystem saveSystem;
    public Canvas canvas;
    public Camera camera;
    public CanvasController canvasController;
    //public GameObject levelLoader;

    // logic
    public string actualLevel;
    public int leaves;
    public int health;
    public Vector2 lastPosition;
    
    // methods to save the state of the game and to load the game

    public void SaveState()
    {   
        // setting the new values that will be stored
        actualLevel = SceneManager.GetActiveScene().name;
        lastPosition.x = player.transform.position.x; 
        lastPosition.y = player.transform.position.y;
        health = player.currentHealth;
       // inventory.items = player.inventory.items;
        
        // saving the actual state of the game
        saveSystem.Save();
        Debug.Log("Game Saved! Thank you for your preference.");
    }
/*
    public void LoadState()
    {
        PlayerData data = saveSystem.Load();
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(data.level))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(data.level));
        }
        // SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        
        player.gameObject.transform.position = new Vector2(data.position[0], data.position[1]);
        player.currentHealth = data.health;
       // player.inventory.items = data.inventory.items;
    }*/
}

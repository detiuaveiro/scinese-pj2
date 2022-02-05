using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerMovement pMove;
    public Inventory inventory;
    
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;
    protected Vector2 pushDirection;
    public Rigidbody2D rb;
    public AudioSource sfx;

    public GameOver_Menu gameOver;

    [SerializeField] DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

   //[SerializeField] private Item_Data[] items = new Item_Data[4];
   // [SerializeField] private int invSpace = 4;
    public GameObject[] slots = new GameObject[4];
    [SerializeField] private readonly bool[] isSlotFull = new bool[4];
    [SerializeField] private readonly bool[] itemIn = new bool[4];

    private void Awake()
    {
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>());
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), this.gameObject.GetComponent<Animator>());
        inventory = new Inventory(slots, isSlotFull);
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            sfx.loop = true;
            sfx.Play();
        }
        else
        {
            sfx.Pause();
            sfx.loop = false;
        }
        pMove.GetMovementInput();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
        //Debug.Log(this.inventory.items.Count);



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(1);
        //}
    }

    void TakeDamage(Damage damage)
    {
        

        if (Time.time - lastImmune >= immuneTimeCooldown)
        {
            lastImmune = Time.time;
            currentHealth -= damage.damage;
            healthBar.SetHealth(currentHealth);

            // push direction, the enemy should be pushed backwards, so, you first need the position of the enemy, then the origin position (in this case, the player's)
            pushDirection = (this.transform.position - damage.originOfAttack).normalized * damage.pushForce;

            if (currentHealth == 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
        // panel.SetActive(true);
        gameOver.EndGame();
    }

    public void FixedUpdate()
    {

        pMove.Move(sfx);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // will only save the state of the game if you press "E"
        if (other.gameObject.name.Contains("Checkpoint")) 
        {
            GameManager.instance.SaveState();
        }

        //if (other.gameObject.CompareTag("LowerEnemy"))
        //{
            
        //}
    }

}

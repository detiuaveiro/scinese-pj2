using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerMovement pMove;
    public Inventory inventory;
    
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    Animator anim;
    bool isAttacking =false;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;
   
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
        anim = GetComponent<Animator>();
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), anim);
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
        if (Input.GetKeyDown(KeyCode.Space)) // right click to attack/swing
        {
            
            anim.SetBool("isAttacking" ,true);
            isAttacking = true;
            
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
        if(isAttacking == false) // para andar um pouco e depois parar de andar completamente
        {
            pMove.Move(sfx);
        }
        if(isAttacking == true)
        {
            rb.MovePosition(rb.position);
        }

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

    public void animAttackEnded () 
    {
        anim.SetBool("isAttacking" ,false);
        isAttacking = false;
    }

}

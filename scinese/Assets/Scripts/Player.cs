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

    public GameOver_Menu gameOver;

    private float speed = 3f;
    [SerializeField] private int invSpace = 4;

    private void Awake()
    {
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>());
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), speed, this.gameObject.GetComponent<Animator>());
        inventory = new Inventory(invSpace);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        pMove.GetMovementInput();
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
        pMove.Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("entering oncollisionenter2d function");
        // Debug.Log(other.gameObject.name);

        // will only save the state of the game if you press "E"
        if (other.gameObject.name.Contains("Checkpoint")) 
        {
            GameManager.instance.SaveState();
        }
    }

}

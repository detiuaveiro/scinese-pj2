using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement pMove;
    public Inventory inventory;

    private float speed = 3f;
    [SerializeField] private int invSpace = 4;

    private void Awake()
    {
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>());
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), speed);
        inventory = new Inventory(invSpace);
    }

    public void Update()
    {
        pMove.GetMovementInput();
        //Debug.Log(this.inventory.items.Count);
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

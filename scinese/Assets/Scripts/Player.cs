using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerMovement pMove;
    public Inventory inventory;

    private float speed = 5f;
    [SerializeField] private int invSpace = 4;

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("Player already exists!");
            return;
        }
        instance = this;
        #endregion


        Debug.Log(this.gameObject.GetComponent<Rigidbody2D>());
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), speed);
        inventory = new Inventory(invSpace);
    }

    public void Update()
    {
        pMove.GetMovementInput();
        Debug.Log(this.inventory.items.Count);
    }

    public void FixedUpdate()
    {
        pMove.Move();
    }

}

using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement pMove;
    private float speed = 5f;

    private void Awake()
    {
        Debug.Log(this.gameObject.GetComponent<Rigidbody2D>());
        pMove = new PlayerMovement(this.gameObject.GetComponent<Rigidbody2D>(), speed);
    }

    public void Update()
    {
        pMove.GetMovementInput();
    }

    public void FixedUpdate()
    {
        pMove.Move();
    }

}

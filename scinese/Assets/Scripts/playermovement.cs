using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rig;

    public Animator animator;

    Vector2 movement; //como é vetor 2 vai usar o x e o y 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //input no update
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x); //Realizar animações quando as tivermos
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        //movimento
        rig.MovePosition(rig.position + movement * speed * Time.fixedDeltaTime); //Para garantir que a velocidade se mantem igual usamos Time.fixedDeltaTime
    }
}

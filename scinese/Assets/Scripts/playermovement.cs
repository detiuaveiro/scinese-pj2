using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public float speed;
    public Rigidbody2D rig;

    public Animator animator;

    Vector2 movement; //como é vetor 2 vai usar o x e o y 

    public PlayerMovement(Rigidbody2D rig, float speed, Animator animator)
    {
        this.rig = rig;
        this.speed = speed;
        this.animator = animator;
    }

    public void GetMovementInput()
    {
        // input on update funct
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
        //Debug.Log(movement);

        
        animator.SetFloat("Horizontal", movement.x); //Realizar animações quando as tivermos
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }

    public void Move()
    {
        //movement
        // physics on fixed-update funct
        if (movement.x != 0 || movement.y != 0)
        {
            rig.MovePosition(rig.position + movement * speed * Time.fixedDeltaTime); //Para garantir que a velocidade se mantem igual usamos Time.fixedDeltaTime
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public float speed;
    public Rigidbody2D rig;

    public Animator animator;

    Vector2 movement; //como � vetor 2 vai usar o x e o y 

    public PlayerMovement(Rigidbody2D rig, Animator animator)
    {
        this.rig = rig;
        this.animator = animator;
    }

    public void GetMovementInput()
    {
        // input on update funct
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
        //Debug.Log(movement);

        
      
    }

    public void Move()
    {
        //movement
        // physics on fixed-update funct
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Horizontal", movement.x); //Realizar anima��es quando as tivermos
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            speed = 3.8f;

            if(movement.y == 0 ) 
            {
                speed = 4.3f;
            }
            if(movement.x == 0) 
            {
                speed = 3f;
            }
            
            
            rig.MovePosition(rig.position + movement * speed * Time.fixedDeltaTime); //Para garantir que a velocidade se mantem igual usamos Time.fixedDeltaTime
        }
        else 
        {
            animator.SetBool("isMoving", false);
            rig.MovePosition(rig.position); 
        }
        
    }
}

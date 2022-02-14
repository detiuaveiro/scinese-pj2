using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public float speed;
    public float newSpeed;
    public Rigidbody2D rig;

    public Animator animator;
   // public AudioClip sfx;

    public Vector2 movement; //como � vetor 2 vai usar o x e o y 

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

    public void Move(AudioSource sfx)
    {
        //movement
        // physics on fixed-update funct
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Horizontal", movement.x); //Realizar anima��es quando as tivermos
            animator.SetFloat("Vertical", movement.y);
            
            speed = 3f;
            setNewSpeed(movement);
            
            rig.MovePosition(rig.position + movement * newSpeed * Time.fixedDeltaTime); //Para garantir que a velocidade se mantem igual usamos Time.fixedDeltaTime

            //____ timer para permitir um slide
            
        }
        else 
        {
            animator.SetBool("isMoving", false);
            rig.MovePosition(rig.position); 
            
        }
        
    }


     public void setNewSpeed(Vector3 direction) 
    {
        newSpeed = speed;

        if(direction.y == 0 ) 
        {
            newSpeed = speed + speed /7;
        }

        if(direction.x == 0) 
        {
            newSpeed = speed - speed /3.5f;
        }
        
    }

    
}

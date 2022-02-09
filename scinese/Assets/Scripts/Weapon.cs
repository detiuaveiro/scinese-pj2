using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage structure --> damage dealt to the enemy and distance of pushing back
    public int damage = 1;

    // swing weapon
    public Animator animator; // animator controller is the name in the inspector, just "animator" is the name in the code

    public AudioSource sfx;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInParent<Animator>();
       // sfx = GetComponentInParent<AudioSource>();
    }

    //protected override void FixedUpdate()
    //{
    //    base.FixedUpdate();

    //    if (Input.GetKeyDown(KeyCode.Mouse0)) // right click to attack/swing
    //    {
    //        if (Time.time - lastSwing > cooldown) // check if swing is available
    //        {
    //            lastSwing = Time.time;
    //            Swing();
    //            StartCoroutine(BoxActivation());
    //        }
    //    }
    //    else
    //    {
    //        GetComponent<BoxCollider2D>().enabled = false; //Desativar Collider enquanto n�o est� a bater
    //    }

    //}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // right click to attack/swing
        {
            
            animator.SetBool("isAttacking" ,true);
            
        }
    }

    //IEnumerator BoxActivation()//ativar collider no final da anima��o
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    GetComponent<Collider2D>().enabled = true; //ATIVAR COllider para dar damage
    //}


    void OnTriggerEnter2D(Collider2D coll)
    {
        // Debug.Log(coll);
        if (coll.gameObject.CompareTag("LowerEnemy"))
        {
            Damage dmg = new Damage(transform.position, damage);

            sfx.Play();

            // send message to the enemy
            coll.SendMessage("ReceiveDamage", dmg);
            
        }
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage structure --> damage dealt to the enemy and distance of pushing back
    public int damage = 1;
    public float pushForce = 2.0f;

    // swing weapon
    public Animator animator; // animator controller is the name in the inspector, just "animator" is the name in the code
    private float cooldown = 0f; // time you need to spend before swinging again 
    private float lastSwing; // time where the last swing took place
    public BoxCollider2D bc2d;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetKeyDown(KeyCode.Mouse0)) // right click to attack/swing
        {
            if (Time.time - lastSwing > cooldown) // check if swing is available
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
       // Debug.Log(coll);
        if (coll.tag == "LowerEnemy")
        {
            bc2d.gameObject.SetActive(true);
            // create a new damage object, then we'll send it to the lower enemy
            Damage dmg = new Damage(transform.position, damage, pushForce);

            // send message to the enemy
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        //bc2d.gameObject.SetActive(true);//tentei ativar a colisão, apenas quando o player clica no rato
        Debug.Log("Swing!");
        animator.SetTrigger("Attack");
    }
}
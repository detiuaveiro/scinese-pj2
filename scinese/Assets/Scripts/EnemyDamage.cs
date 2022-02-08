using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Collidable
{
    private Animator animator;
    private AudioSource sfx;

    private void Start()
    {
        //   animator = GetComponentInParent<Animator>();
        sfx = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Debug.Log(coll);
        if (coll.gameObject.CompareTag("Player"))
        {
           // animator.SetTrigger("Attack");
            // create a new damage object, then we'll send it to the lower enemy
            Damage dmg = new Damage(transform.position, 1, 0.2f);
            sfx.Play();

            // send message to the enemy
            coll.SendMessage("TakeDamage", dmg);
        }
    }
}

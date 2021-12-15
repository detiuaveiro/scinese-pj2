using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerEnemy : MonoBehaviour
{
    public int numberOfLives = 2;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;

    protected Vector2 pushDirection;

    public void ReceiveDamage(Damage damage)
    {
        if (Time.time - lastImmune >= immuneTimeCooldown)
        {
            lastImmune = Time.time;
            numberOfLives -= damage.damage;

            // push direction, the enemy should be pushed backwards, so, you first need the position of the enemy, then the origin position (in this case, the player's)
            pushDirection = (this.transform.position - damage.originOfAttack).normalized * damage.pushForce;
        
        if (numberOfLives <= 0)
            {
                numberOfLives = 0;
                Death();
            }
        }
    }

    public void Death()
    {
        Debug.Log("A lower enemy was killed!");
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Vector3 originOfAttack; // position of the origin of the damage  taken
    public int damage;
    public float pushForce;

    public Damage(Vector2 originOfAttack, int damage, float pushForce)
    {
        this.originOfAttack = originOfAttack;
        this.damage = damage;
        this.pushForce = pushForce;
    }
}
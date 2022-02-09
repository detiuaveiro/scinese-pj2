using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Vector3 originOfAttack; // position of the origin of the damage  taken
    public int damage;
    

    public Damage(Vector2 originOfAttack, int damage)
    {
        this.originOfAttack = originOfAttack;
        this.damage = damage;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private Collider2D boxCollider; // changed to only Collider2D so that we can use other types of colliders :D
    private Collider2D[] hits = new Collider2D[10]; // will store up to 10 different object that we're colliding with

    protected virtual void Awake()
    {
        boxCollider = this.gameObject.GetComponent<Collider2D>(); // get the boxCollider2D that we added to the gameobject that has this script
    }

    protected virtual void FixedUpdate()
    {
        // collision work
        boxCollider.OverlapCollider(filter, hits); // check for collisions beneath or above our current box collider 2D
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) // no collisions at the moment
            {
                continue;
            }

            OnCollide(hits[i]);

            // clean the array
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide was not implemented in " + coll.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    //If player  projectile hits enemy they take 1 damage
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamageExternal(1);
        }
        base.OnTriggerEnter2D(collision);
    }
}

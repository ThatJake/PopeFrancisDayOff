using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : BaseProjectile
{

    //If Projectile hits Player -> Player gets 1 damage
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamageExternal(1);
            base.Deactivate();
        }
        base.OnTriggerEnter2D(collision);
    }

}

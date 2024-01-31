using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    public PlayerMovement pM;
    public PlayerStats pS;

    public void Start()
    {
        pM = GetComponent<PlayerMovement>();
        pS = GetComponent<PlayerStats>();
    }

    //If player  projectile hits enemy they take 1 damage and add 1 xp to player
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamageExternal(1);
            pS.AddXP(1);
            pM.SetJumpSpeed(pS.newJumpSpeed);
            base.Deactivate();
        }
        base.OnTriggerEnter2D(collision);
    }
}

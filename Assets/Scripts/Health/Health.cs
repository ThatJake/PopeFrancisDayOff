using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

     private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    //taking damage, within reasonable limits for health
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        
        if (currentHealth > 0) //what happens if player/enemy is still alive
        {
            anim.SetTrigger("hurt");
        }
        else //what happens if player/enemy is dead
        {
            Die();
        }
        
    }

    //restoring health
    public void AddHealth(float healthValue)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthValue, 0, startingHealth);
    }

    //what happens if player/enemy is dead
    public void Die()
    {
        if (!dead)
        {   //play death animation
            anim.SetTrigger("die");
        
            if (GetComponent<PlayerMovement>() != null) // when player dies
            {   
                
                GetComponent<PlayerMovement>().enabled = false;
               
            }

            if (GetComponent<RangedEnemy>() != null) // when enemy dies
            {
                GetComponent<RangedEnemy>().enabled = false;
                
            }
        }
    }

    //Taking damage from projectiles

    public void TakeDamageExternal(float damage)
    {
        TakeDamage(damage);
    }
}

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
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            Die();
        }
        
    }

    public void AddHealth(float healthValue)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthValue, 0, startingHealth);
    }

    public void Die()
    {
        if (!dead)
        {
            anim.SetTrigger("die");
        
            if (GetComponent<PlayerMovement>() != null)
            {   
                
                GetComponent<PlayerMovement>().enabled = false;
               
            }

            if (GetComponent<RangedEnemy>() != null)
            {
                GetComponent<RangedEnemy>().enabled = false;
                
            }
        }
    }

    public void TakeDamageExternal(float damage)
    {
        TakeDamage(damage);
    }
}

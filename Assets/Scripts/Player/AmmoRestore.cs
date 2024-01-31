using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRestore : MonoBehaviour
{
    [SerializeField] private float ammoValue;

    //If player collides with the ammo potion he regains a set amount of ammo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>().currentAmmo < 5)
            {
                collision.GetComponent<PlayerMovement>().AddAmmo(ammoValue);
                gameObject.SetActive(false);
            }
        }
    }
}
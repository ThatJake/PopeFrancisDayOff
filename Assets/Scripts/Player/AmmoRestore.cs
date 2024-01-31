using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRestore : MonoBehaviour
{
    [SerializeField] private float ammoValue;


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
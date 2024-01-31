using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour

    //Setup for enemies shooting projectiles
{
    [Header("Attack Parameters")]
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] public Transform firepoint;
    [SerializeField] public GameObject[] ectoplasm;


    //access to projectiles
    public int FindEctoplasm()
    {
        for (int i = 0; i < ectoplasm.Length; i++)
        {
            if (!ectoplasm[i].activeInHierarchy) 
                return i;
        }

        return 9;
    }

     private void Deactivate() //remove ghost
    { 
        gameObject.SetActive(false);
    }

}

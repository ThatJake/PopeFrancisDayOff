using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private RangedEnemy rE;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        rE = GetComponent<RangedEnemy>();
    }


    void Update()
       
     //Limit attacks to a time interval.
    {
        cooldownTimer += Time.deltaTime;


        if (cooldownTimer >= 2)
        {
            cooldownTimer = 0;
            Attacking();
           
        }
    }

    //access to pooled projectiles and firing them off
    private void Attacking()
    {
        rE.ectoplasm[rE.FindEctoplasm()].transform.position = rE.firepoint.position;
        float enemyDirection = rE.transform.localScale.x;
        rE.ectoplasm[rE.FindEctoplasm()].GetComponent<BaseProjectile>().SetDirection(enemyDirection * -1);
    }
}

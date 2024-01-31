using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private RangedEnemy rE;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        rE = GetComponent<RangedEnemy>();
    }
    void Update()
       
    {
        cooldownTimer += Time.deltaTime;


        if (cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
            Attacking();
           
        }
    }
    private void Attacking()
    {
        rE.ectoplasm[rE.FindEctoplasm()].transform.position = rE.firepoint.position;
        float enemyDirection = rE.transform.localScale.x;
        rE.ectoplasm[rE.FindEctoplasm()].GetComponent<BaseProjectile>().SetDirection(enemyDirection * -1);
    }
}

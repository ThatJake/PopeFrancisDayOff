using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private PlayerMovement pM;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]private AudioClip holyWaterSound;

    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown && pM.canAttack())
        {
            Attacking();

            cooldownTimer += Time.deltaTime;
        }
    }
    private void Attacking()
    {       
            SoundManager.instance.PlaySound(holyWaterSound);
            pM.currentAmmo = Mathf.Clamp(pM.currentAmmo - 1, 0, pM.startingAmmo);
            pM.holyWater[pM.FindHolyWater()].transform.position = pM.firePoint.position;
            pM.holyWater[pM.FindHolyWater()].GetComponent<BaseProjectile>().SetDirection(Mathf.Sign(pM.transform.localScale.x));       
    }
}

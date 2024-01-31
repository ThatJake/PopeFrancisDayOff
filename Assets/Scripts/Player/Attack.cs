using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private PlayerMovement pM;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]private AudioClip holyWaterSound;

    // get access to player movement script
    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
    }

    //check if player wants to attack(input) and if player is able to
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown && pM.canAttack())
        {
            Attacking();

            cooldownTimer += Time.deltaTime;
        }
    }
    private void Attacking() //what happens when player attacks
    {       
            SoundManager.instance.PlaySound(holyWaterSound); //swoosh sound
            pM.currentAmmo = Mathf.Clamp(pM.currentAmmo - 1, 0, pM.startingAmmo); //decrease ammo
            pM.holyWater[pM.FindHolyWater()].transform.position = pM.firePoint.position; //access to pooled holywater objects
            pM.holyWater[pM.FindHolyWater()].GetComponent<BaseProjectile>().SetDirection(Mathf.Sign(pM.transform.localScale.x)); //firing them off      
    }
}

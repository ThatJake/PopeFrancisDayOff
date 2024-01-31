using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start() // filling healthbar at start
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update() // filling healthbar approprietly to players health
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}

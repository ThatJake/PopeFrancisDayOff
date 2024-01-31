using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerAmmo;
    [SerializeField] private Image totalAmmoBar;
    [SerializeField] private Image currentAmmoBar;

    private void Start()
    {
        totalAmmoBar.fillAmount = playerAmmo.currentAmmo / 5;
    }

    private void Update()
    {
        currentAmmoBar.fillAmount = playerAmmo.currentAmmo / 5;
    }
}

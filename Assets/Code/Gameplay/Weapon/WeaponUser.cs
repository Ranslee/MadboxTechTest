using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponUser : MonoBehaviour
{
    [SerializeField] private PlayerControl characterControl;
    [SerializeField] private EnemyDetection enemyDetection;
    [SerializeField] private GameObject weaponSlot;

    private GameObject currentWeapon;
    private bool weaponEquipped;

    public void EquipWeapon(WeaponData data)
    {
        if (weaponEquipped)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(data.Prefab, weaponSlot.transform);
        weaponEquipped = true;

        characterControl.UpdateWeapon(data);
        enemyDetection.SetDetectionRange(data.AttackRange);
    }
}
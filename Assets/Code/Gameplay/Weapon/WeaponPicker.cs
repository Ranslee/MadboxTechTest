using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Madbox.CheatConsole;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] private WeaponUser weaponUser;
    [SerializeField] private WeaponSet weaponSet;

    private void Awake()
    {
        weaponUser.EquipWeapon(ChooseRandomWeapon());
        MBCheatConsole.RegisterCheat(new ButtonCheat()
        {
            Category = "Core",
            Name = "Choose Random Weapon",
            Callback = () => { weaponUser.EquipWeapon(ChooseRandomWeapon()); }
        });
        weaponSet.RegisterCheats();
    }

    private WeaponData ChooseRandomWeapon()
    {
        int weightSum = 0;
        for (int i = 0; i < weaponSet.Weapons.Count; i++)
        {
            weightSum += weaponSet.Weapons[i].ProbabilityWeight;
        }

        int random = Random.Range(0, weightSum);

        for (int i = 0; i < weaponSet.Weapons.Count; i++)
        {
            random -= weaponSet.Weapons[i].ProbabilityWeight;
            if (random <= 0)
                return weaponSet.Weapons[i].WeaponData;
        }

        return default; // we'd throw here
    }
}

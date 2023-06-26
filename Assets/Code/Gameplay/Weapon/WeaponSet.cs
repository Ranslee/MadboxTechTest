using System.Collections.Generic;
using System;
using UnityEngine;
using Madbox.CheatConsole;

[CreateAssetMenu(fileName = "NewWeaponSet", menuName = "GameData/WeaponSet")]
public class WeaponSet : GameAsset
{
    [SerializeField] private List<WeaponEntry> weapons;

    public IReadOnlyList<WeaponEntry> Weapons => weapons;

    [Serializable]
    public struct WeaponEntry
    {
        public WeaponData WeaponData;
        public int ProbabilityWeight;
    }

    public void RegisterCheats()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].WeaponData.RegisterCheats();
        }
    }
}
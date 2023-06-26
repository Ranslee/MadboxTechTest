using UnityEngine;
using Madbox.CheatConsole;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "GameData/WeaponData")]
public class WeaponData : GameAsset
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackRange;

    public GameObject Prefab => prefab;
    public float AttackSpeed => attackSpeed;
    public float MovementSpeed => movementSpeed;
    public float AttackRange => attackRange;

    public void RegisterCheats()
    {
        MBCheatConsole.RegisterCheat(new FloatCheat()
        {
            Category = "Core",
            Name = $"{name}: attackSpeed",
            CurrentValue = attackSpeed,
            Callback = (float newValue) => { attackSpeed = newValue; },
        });

        MBCheatConsole.RegisterCheat(new FloatCheat()
        {
            Category = "Core",
            Name = $"{name}: movementSpeed",
            CurrentValue = movementSpeed,
            Callback = (float newValue) => { movementSpeed = newValue; },
        });

        MBCheatConsole.RegisterCheat(new FloatCheat()
        {
            Category = "Core",
            Name = $"{name}: attackRange",
            CurrentValue = attackRange,
            Callback = (float newValue) => { attackRange = newValue; },
        });
    }
}

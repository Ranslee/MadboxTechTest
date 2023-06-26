using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerData", menuName = "GameData/SpawnerData")]
public class SpawnerData : GameAsset
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int minimumAmount;
    [SerializeField] private int maximumAmount;

    public GameObject EnemyPrefab => enemyPrefab;
    public int MinimumAmount => minimumAmount;
    public int MaximumAmount => maximumAmount;
}

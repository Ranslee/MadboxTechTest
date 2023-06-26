using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;
    [SerializeField] private BoxCollider spawnArea;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        int count = Random.Range(spawnerData.MinimumAmount, spawnerData.MaximumAmount + 1); // +1 because max is exclusive

        for (int i = 0; i < count; i++)
        {
            Instantiate(spawnerData.EnemyPrefab, spawnArea.RandomPointInBox(), Quaternion.identity, transform);
        }
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] Vector2 spawnArea;

    public void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 position = new Vector3();
        float sign = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f) {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * sign;

        } else {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * sign;
        }
        position.z = 0;

        return position;
    }
}

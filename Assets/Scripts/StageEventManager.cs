using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemySpawner enemiesManager;

    int eventIndexr;
    StageTime stageTime;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndexr < stageData.StageEvents.Count)
        {
            if (stageTime.time >= stageData.StageEvents[eventIndexr].time)
            {
                Debug.Log(stageData.StageEvents[eventIndexr].message);

                for (int i = 0; i < stageData.StageEvents[eventIndexr].count; i++)
                {
                    enemiesManager.SpawnEnemy(stageData.StageEvents[eventIndexr].enemyToSpawn);
                }

                eventIndexr++;
            }
        }
    }
}

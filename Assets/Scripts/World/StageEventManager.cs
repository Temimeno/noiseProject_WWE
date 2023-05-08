using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] enemiesManager enemiesManager;

    WorldTimer worldTimer;
    int eventIndexer;
    WinManager winManager;

    private void Awake()
    {
        worldTimer = GetComponent<WorldTimer>();
    }

    private void Start()
    {
        winManager =  FindObjectOfType<WinManager>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count)
        {
            return;
        }

        if (worldTimer.time > stageData.stageEvents[eventIndexer].time)
        {
            switch(stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.SpawnEnemy:
                    SpawnEnemy(false);
                    break;
                case StageEventType.SpawnBoss:
                    SpawnReportEnemyBoss();
                    break;
                case StageEventType.WinStage:
                    winStage();
                    break;
            }

            Debug.Log(stageData.stageEvents[eventIndexer].message);
            eventIndexer += 1;
        }
    }

    private void SpawnEnemy(bool bossEnemy)
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn, bossEnemy);
        }
    }

    private void SpawnReportEnemyBoss()
    {
        SpawnEnemy(true);
    }

    public void winStage()
    {
        winManager.Win();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemiesManager : MonoBehaviour
{
    [SerializeField] StageProgression stageProgression;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    [SerializeField] GameWinning winPanel;

    public List<ReportEnemy> bossList;
    public int totalBossHP;
    public int currentBossHP;
    [SerializeField] Slider bossHPBar;
    GameObject newEnemy;

    private void Awake()
    {
        winPanel =  FindObjectOfType<GameWinning>(true);
    }

    private void Start()
    {
        bossHPBar = FindObjectOfType<BossHPBar>(true).GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateBossHP();
    }

    private void UpdateBossHP()
    {
        if (bossList == null)
        {
            return;
        }

        if (bossList.Count == 0)
        {
            return;
        }

        currentBossHP = 0;

        for (int i = 0; i < bossList.Count; i++)
        {
            if (bossList[i] == null)
            {
                continue;
            }
            currentBossHP += bossList[i].stats.hp;
        }

        bossHPBar.value = currentBossHP;

        if (currentBossHP <= 0 )
        {
            bossHPBar.gameObject.SetActive(false);
            bossList.Clear();
            Time.timeScale = 0f;
            winPanel.gameObject.SetActive(true);
        }
    }

    public void SpawnEnemy(EnemyData enemyToSpawn, bool isBoss)
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        if(isBoss == true)
        {
            newEnemy = Instantiate(boss);
        }
        else
        {
            newEnemy = Instantiate(enemy);
        }
        newEnemy.transform.position = position;

        ReportEnemy newEnemyComponent = newEnemy.GetComponent<ReportEnemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatesForProgrss(stageProgression.Progress);

        if(isBoss == true)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;

        GameObject spriteOBJ = Instantiate(enemyToSpawn.animatedPrfab);
        spriteOBJ.transform.parent = newEnemy .transform;
        spriteOBJ.transform.localPosition = Vector3.zero;
    }

    private void SpawnBossEnemy(ReportEnemy newBoss)
    {
        if(bossList == null)
        {
            bossList = new List<ReportEnemy>();
        }

        bossList.Add(newBoss);

        totalBossHP += newBoss.stats.hp;

        bossHPBar.gameObject.SetActive(true);
        bossHPBar.maxValue = totalBossHP;
    }

    public Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;

        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}

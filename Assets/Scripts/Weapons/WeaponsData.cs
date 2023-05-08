using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] 
public class WeaponsStats
{
    public int damage;
    public float timeToAttack;

    public WeaponsStats(int damage, float timeToAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
    }

    internal void Sum(WeaponsStats weaponsStatsUpgrade)
    {
        this.damage += weaponsStatsUpgrade.damage;
        this.timeToAttack += weaponsStatsUpgrade.timeToAttack;
    }
}

[CreateAssetMenu]
public class WeaponsData : ScriptableObject
{
    public string Name;
    public WeaponsStats stats;
    public GameObject weaponsBasePrefab;
    public List<UpgradeData> upgrades;
}

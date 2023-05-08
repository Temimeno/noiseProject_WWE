using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    WeaponUnlock
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string name;
    public Sprite icon;

    public WeaponsData weaponsData;
    public WeaponsStats weaponsStatsUpgrade;
}

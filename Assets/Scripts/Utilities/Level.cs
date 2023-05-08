using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] expBar expbar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> aquiredUpgrade;

    WeaponsManager weaponsManager;

    private void Awake()
    {
        weaponsManager = GetComponent<WeaponsManager>();
    }

    int To_Level_Up
    {
        get
        {
            return level * 600;
        }
    }

    void Start()
    {
        expbar.UpdateExpSlider(experience, To_Level_Up);
        expbar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        LevelUp();
        expbar.UpdateExpSlider(experience, To_Level_Up);
    }

    public void LevelUp()
    {
        if(experience >= To_Level_Up)
        {
            if(selectedUpgrades == null)
            {
                selectedUpgrades = new List<UpgradeData>();
            }
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(GetUpgrades(3));

            upgradePanel.OpenPanel(selectedUpgrades);
            experience -= To_Level_Up;
            level += 1;
            expbar.SetLevelText(level);
        }    
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradelist = new List<UpgradeData>();

        if (count >= upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradelist.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradelist;
    }

    public void Upgrades(int selectedUpgradesID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradesID];

        if (aquiredUpgrade == null)
        {
            aquiredUpgrade = new List<UpgradeData>();
        }

        switch(upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUnlock:
                weaponsManager.AddWeapon(upgradeData.weaponsData);
                upgrades.Remove(upgradeData);
                break;
            case UpgradeType.WeaponUpgrade:
                weaponsManager.UpgradeWeapon(upgradeData);
                break;
        }

        aquiredUpgrade.Add(upgradeData);
    }

    internal void addUpgradeToListofAvaliableUpgrade(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }
}

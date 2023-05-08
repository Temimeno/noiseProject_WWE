using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjContainer;
    [SerializeField] WeaponsData startingWeapon;

    List<WeaponsBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponsBase>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponsData weaponsData)
    {
        GameObject weaponGameOBJ = Instantiate(weaponsData.weaponsBasePrefab, weaponObjContainer);

        WeaponsBase weaponsBase = weaponGameOBJ.GetComponent<WeaponsBase>();

        weaponsBase.SetData(weaponsData);
        weapons.Add(weaponsBase);

        weaponGameOBJ.GetComponent<WeaponsBase>().SetData(weaponsData);
        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.addUpgradeToListofAvaliableUpgrade(weaponsData.upgrades);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponsBase weaponsToUpgrade = weapons.Find(wd => wd.weaponsData == upgradeData.weaponsData);
        weaponsToUpgrade.Upgrade(upgradeData);
    }
}

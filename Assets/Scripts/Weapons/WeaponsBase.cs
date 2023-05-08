using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionOfAttack
{
    None,
    Forward,
    LeftRight,
    Updown
}

public abstract class WeaponsBase : MonoBehaviour
{
    NewController newController;

    public WeaponsData weaponsData;

    public WeaponsStats weaponsStats;

    float timer;

    playerStats wielder;

    public Vector2 vectorOfAttack;
    [SerializeField] DirectionOfAttack attackDirection;


    private void Awake()
    {
        newController = GetComponentInParent<NewController>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponsStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponsData wd)
    {
        weaponsData = wd;

        weaponsStats = new WeaponsStats(wd.stats.damage, wd.stats.timeToAttack);
    }

    public abstract void Attack();

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponsStats.Sum(upgradeData.weaponsStatsUpgrade);
    }

    public void AddOwnerCharacter(playerStats playerStats)
    {
        wielder = playerStats;
    }

    public void UpdateVectorOfAttack()
    {
        if (attackDirection == DirectionOfAttack.None)
        {
            vectorOfAttack = Vector2.zero;
            return;
        }

        switch (attackDirection)
        {
            case DirectionOfAttack.Forward:
                break;
            case DirectionOfAttack.LeftRight:
                vectorOfAttack.x = newController.lastHorizontalMove;
                vectorOfAttack.y = 0f;
                break;
            case DirectionOfAttack.Updown:
                vectorOfAttack.x = 0f;
                vectorOfAttack.y = newController.lastVerticalMove;
                break;
        }
        vectorOfAttack = vectorOfAttack.normalized;
    }
}

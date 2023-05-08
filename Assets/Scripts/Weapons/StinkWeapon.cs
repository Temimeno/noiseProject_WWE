using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkWeapon : WeaponsBase
{
    [SerializeField] GameObject Effect;

    NewController newController;
    [SerializeField] Vector2 suitAttackSize = new Vector2(5f, 5f);

    void Awake()
    {
        newController = GetComponentInParent<NewController>();
    }

    void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            ReportEnemy e = colliders[i].GetComponent<ReportEnemy>();
            if(e != null)
            {
                e.TakeDamage(weaponsStats.damage);
            }
        }
    }

    public override void Attack()
    {
        if(Time.timeScale != 0)
        {
            Effect.SetActive(true);
            Collider2D[] colliders =  Physics2D.OverlapBoxAll(Effect.transform.position, suitAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }
}

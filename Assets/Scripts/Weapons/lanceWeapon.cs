using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceWeapon : WeaponsBase
{
    [SerializeField] GameObject rightLance;
    [SerializeField] GameObject leftLance;

    NewController newController;
    [SerializeField] Vector2 lanceAttackSize = new Vector2(2f, 5f);

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
        if(newController.lastHorizontalMove < 0)
        {
            rightLance.SetActive(true);
            Collider2D[] colliders =  Physics2D.OverlapBoxAll(rightLance.transform.position, lanceAttackSize, 0f);
            ApplyDamage(colliders);
        } else

        {
            leftLance.SetActive(true);
            Collider2D[] colliders =  Physics2D.OverlapBoxAll(leftLance.transform.position, lanceAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }
}

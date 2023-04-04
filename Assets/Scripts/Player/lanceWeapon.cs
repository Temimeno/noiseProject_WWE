using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceWeapon : MonoBehaviour
{
        [SerializeField] float timeToAttack = 4;
        float timer;

        [SerializeField] GameObject rightLance;
        [SerializeField] GameObject leftLance;

        NewController newController;
        [SerializeField] Vector2 lanceAttackSize = new Vector2(4f, 2f);
        [SerializeField] int lanceDamage = 1;

    void Awake()
    {
        newController = GetComponentInParent<NewController>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer =timeToAttack;

        if(newController.lastHorizontalMove > 0)
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

    void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            enemyMovement e =colliders[i].GetComponent<enemyMovement>();
            if(e != null)
            {
                colliders[i].GetComponent<enemyMovement>().TakeDamage(lanceDamage);
            }
        }
    }
}

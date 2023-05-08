using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 4;
    public int damage = 1;
    public float speed = 2f;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.speed = stats.speed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class ReportEnemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGamobject;
    playerStats targetCharacter;

    Rigidbody2D rb;

    public EnemyStats stats;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGamobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * stats.speed;
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGamobject)
        {
            Attack();
        }
    }

    void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGamobject.GetComponent<playerStats>();
        }

        targetCharacter.TakeDamage(stats.damage);
    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if (stats.hp < 1)
        {
            Destroy(gameObject);
        }
    }

    internal void UpdateStatesForProgrss(float progress)
    {
        stats.ApplyProgress(progress);
    }
}

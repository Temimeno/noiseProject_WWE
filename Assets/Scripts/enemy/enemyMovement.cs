using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGamobject;
    playerStats targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rb;

    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int exp_reward = 400;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGamobject = target;
        targetDestination =target.transform;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
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

        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            targetGamobject.GetComponent<Level>().AddExperience(exp_reward);
            Destroy(gameObject);
        }
    }
}

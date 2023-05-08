using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerStats c = collision.GetComponent<playerStats>();
        if(c != null)
        {
            GetComponent<iPickupObject>().OnPickup(c);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }
}

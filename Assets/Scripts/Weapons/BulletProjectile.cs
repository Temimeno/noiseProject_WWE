using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 10;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    bool hitDetection = false;
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        Collider2D[] hit =  Physics2D.OverlapCircleAll(transform.position, 0.3f);
        foreach (Collider2D c in hit)
            {
            ReportEnemy enemy = c.GetComponent<ReportEnemy>();
            if (enemy != null)
            {  
                enemy.TakeDamage(damage);
                hitDetection = true;
                break;
            }
        }

        if(hitDetection == true)
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WeaponsBase
{
    NewController newController;

    [SerializeField] GameObject bulletPrefab;


    public override void Attack()
    {
        UpdateVectorOfAttack();

        GameObject pencilBullet = Instantiate(bulletPrefab);
        pencilBullet.transform.position = transform.position;
        
        BulletProjectile bulletProjectile = pencilBullet.GetComponent<BulletProjectile>();
        bulletProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);

        bulletProjectile.damage = weaponsStats.damage;
    }
}

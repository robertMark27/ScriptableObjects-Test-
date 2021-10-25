using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Enemy data.
    public EnemyData enemy;

    //Epload particle system.
    public ParticleSystem expload;

    //Bullet life time until destroy.
    public float bulletLife;

    private void Update()
    {
        //Check if the bullet life time is over and destroy the bullet.
        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0)
            BulletDestroy();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the bullet touches the ground.
        if (collision.transform.tag == "Ground")
        {
            BulletDestroy();
        }
    }
    private void OnEnable()
    {
        EnemyScript.DamageEnemy += EnemyDamage;
    }
    private void OnDisable()
    {
        EnemyScript.DamageEnemy -= EnemyDamage;
    }

    private void EnemyDamage()
    {
        enemy.enemyHealth -= 20;
        print(enemy.enemyHealth);
        BulletDestroy();
    }
    private void BulletDestroy()
    {
        //Instantiate expload particle effect.
        ParticleSystem exploadParticle = Instantiate(expload, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}

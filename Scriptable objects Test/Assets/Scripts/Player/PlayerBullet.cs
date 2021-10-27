using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
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
        BulletDestroy();
    }

    private void BulletDestroy()
    {
        //Instantiate expload particle effect.
        ParticleSystem exploadParticle = Instantiate(expload, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}

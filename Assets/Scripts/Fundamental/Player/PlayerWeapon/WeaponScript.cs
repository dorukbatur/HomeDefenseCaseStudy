using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private ParticleSystem gunparticle;
    
    
    public void FireGun(int bulletDamage)
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos); 
        var particle = Instantiate(gunparticle, bulletSpawnPos);
        Destroy(particle.gameObject, 1f);
        bullet.transform.rotation = bulletSpawnPos.transform.rotation;
        bullet.SetSpeedtoBullet(bulletDamage);
        bullet.transform.parent = null;
        Destroy(bullet.gameObject, 2f);
    }
}

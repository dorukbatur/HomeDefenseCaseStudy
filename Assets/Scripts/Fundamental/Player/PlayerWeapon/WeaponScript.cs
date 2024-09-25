using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Bullet bulletPrefab;

    
    public void FireGun(int bulletDamage)
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos);
        bullet.transform.rotation = bulletSpawnPos.transform.rotation;
        bullet.SetSpeedtoBullet(bulletDamage);
        bullet.transform.parent = null;
        Destroy(bullet.gameObject, 2f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private ParticleSystem bloodparticleSystem;
    private int bulletDamage;

    public void SetSpeedtoBullet(int bulletDamage)
    {
        rb.velocity = transform.forward * bulletSpeed;
        this.bulletDamage = bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageReceiver receiver = other.GetComponent<DamageReceiver>();
        if (receiver)
        {
            receiver.OnTakeDamage(bulletDamage);
            UIManager.instance.UIShootingScreenManager.GiveShootFeedback();
            ParticleSystem particle = Instantiate(bloodparticleSystem, receiver.transform.position, bloodparticleSystem.transform.rotation,
                receiver.transform);
            particle.transform.parent = null;
            Destroy(particle.gameObject, 1f);
            gameObject.SetActive(false);
        }
    }
}

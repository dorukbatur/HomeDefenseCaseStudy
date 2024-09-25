using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
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
            gameObject.SetActive(false);
        }
    }
}

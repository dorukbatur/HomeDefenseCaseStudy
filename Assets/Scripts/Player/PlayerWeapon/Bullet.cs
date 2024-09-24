using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    private int hitEffect = 1;

    public void SetSpeedtoBullet()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        
        todo hit ettiğinde hit effect 0 yap damage at
    }*/
}

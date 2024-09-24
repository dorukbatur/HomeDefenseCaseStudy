using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCTRL : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed;
    private Transform targetPos;
    private Vector3 direction;
    public void Init(Transform targetPos, float speed)
    {
        this.targetPos = targetPos;
        this.speed = speed;
    }

    private void Update()
    {
        /*direction = Vector3.Normalize(targetPos.position - transform.position);
        rb.velocity = direction * speed;*/
    }
}

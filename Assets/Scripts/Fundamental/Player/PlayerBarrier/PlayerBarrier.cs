using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [SerializeField] private int healthPoints = 200;
    private int healthPointsOnStart;

    private void Start()
    {
        healthPointsOnStart = healthPoints;
    }

    public int HealthPoints => healthPoints;


    public void TakeDamage(int damage)
    {
        if (HealthPoints > 0)
        {
            healthPoints -= damage;
        }
        SetBarrierLevel();
    }

    private void SetBarrierLevel()
    {
        float y = (float) healthPoints / (float) healthPointsOnStart;
        transform.localPosition = new Vector3(transform.localPosition.x, y-1, transform.localPosition.z);
    }

}

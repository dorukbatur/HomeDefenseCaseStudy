using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 1f;
    [SerializeField] private List<EnemyCTRL> enemies;
    private SubLevelManager parentSubLevel;
    private Transform playerFightPos;
    
    public void Init(SubLevelManager parentSubLevel, Transform playerFightPos)
    {
        this.parentSubLevel = parentSubLevel;
        this.playerFightPos = playerFightPos;

        
        SetEnemiesOnInit(playerFightPos);
    }


    private void SetEnemiesOnInit(Transform playerFightPos)
    {
        foreach (EnemyCTRL enemy in enemies)
        {
            enemy.Init(playerFightPos,enemySpeed);
        }
    }

}

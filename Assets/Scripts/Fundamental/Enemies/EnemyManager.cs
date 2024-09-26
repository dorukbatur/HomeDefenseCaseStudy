using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 1f;
    [SerializeField] private List<EnemyCTRL> enemies;
    private SubLevelManager parentSubLevel;
    private int OnstartEnemyCount;
    
    
    public void Init(SubLevelManager parentSubLevel, Transform playerFightPos)
    {
        this.parentSubLevel = parentSubLevel;
        SetEnemiesOnInit(playerFightPos);
        OnstartEnemyCount = enemies.Count;
    }
    
    private void SetEnemiesOnInit(Transform playerFightPos)
    {
        foreach (EnemyCTRL enemy in enemies)
        {
            enemy.Init(this,playerFightPos,enemySpeed);
        }
    }

    public void OnEnemyDeath(EnemyCTRL enemyCtrl)
    {
        if (enemies.Contains(enemyCtrl))
            enemies.Remove(enemyCtrl);
        float division = 1 - ((float)enemies.Count / (float)OnstartEnemyCount);
        UIManager.instance.UIShootingScreenManager.GiveProgressBarUpdate(division);
        UIManager.instance.UICommonManager.MoneyParticleSpawner();

        if (enemies.Count == 0)
        {
            parentSubLevel.SubLevelIsCompleted();
        }
    }
}

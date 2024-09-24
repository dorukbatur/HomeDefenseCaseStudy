using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelManager : MonoBehaviour
{
    private LevelManager parentLevelManager;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private Transform playerFightPos;

    public void InitiateSubLevelManager(LevelManager parentLevelManager)
    {
        this.parentLevelManager = parentLevelManager;
        _enemyManager.Init();
    }
}

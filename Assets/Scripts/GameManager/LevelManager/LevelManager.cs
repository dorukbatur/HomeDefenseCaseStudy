using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private List<SubLevelManager> subLevelManagers;
    [SerializeField] private List<Transform> subLevelManagerInstantiatePos;
    [SerializeField] private PlayerCTRL playerController;
    private SubLevelManager activeSubLevel;
    private int subLevelCounter = 0;
    public void InitiateLevelManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
        if (activeSubLevel != null)
        {
            Destroy(activeSubLevel);
        }
        activeSubLevel = Instantiate(subLevelManagers[subLevelCounter], subLevelManagerInstantiatePos[subLevelCounter]);
        activeSubLevel.InitiateSubLevelManager(this);
        playerController.InitPlayerCTRL(subLevelManagerInstantiatePos[subLevelCounter]);
        //todo sublevel counter
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deneme();
        }
    }

    private void deneme()
    {
        //todo süpersin doruk
        if (activeSubLevel != null)
        {
            Destroy(activeSubLevel);
        }

        subLevelCounter++;
        subLevelCounter %= subLevelManagers.Count;
        activeSubLevel = Instantiate(subLevelManagers[subLevelCounter], subLevelManagerInstantiatePos[subLevelCounter]);
        activeSubLevel.InitiateSubLevelManager(this);
        playerController.InitPlayerCTRL(subLevelManagerInstantiatePos[subLevelCounter]);
    }

}

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
    public PlayerCTRL PlayerController => playerController;
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
        subLevelCounter++; //todo
    }


    public void NextSubLevel()
    {
        if (activeSubLevel != null)
        {
            Destroy(activeSubLevel.gameObject, 4f);
        }
        if (subLevelCounter>=subLevelManagers.Count)
        {
            gameManager.LevelEndWithScreen(true);
            return;
        }
        activeSubLevel = Instantiate(subLevelManagers[subLevelCounter], subLevelManagerInstantiatePos[subLevelCounter]);
        activeSubLevel.InitiateSubLevelManager(this);
        playerController.InitPlayerCTRL(subLevelManagerInstantiatePos[subLevelCounter]);
        UIManager.instance.UIShootingScreenManager.ProgressBarInit();
        subLevelCounter++;
    }
    
    

}

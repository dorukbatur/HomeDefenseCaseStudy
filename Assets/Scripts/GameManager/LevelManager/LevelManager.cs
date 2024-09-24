using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private List<SubLevelManager> subLevelManagers;
    [SerializeField] private PlayerCTRL playerController;
    private SubLevelManager activeSubLevel;
    private int subLevelCounter = 0;
    public void InitiateLevelManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
        activeSubLevel = Instantiate(subLevelManagers[subLevelCounter], transform);
        activeSubLevel.InitiateSubLevelManager(this);
        playerController.InitPlayerCTRL();
    }

}

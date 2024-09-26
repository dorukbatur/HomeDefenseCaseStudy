using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager UIManager;
    public WeaponSelectionManager weaponSelectionManager;
    [SerializeField] private List<LevelManager> levelManagers = new List<LevelManager>();
    [SerializeField] private int moneyGainAmount = 40;
    private LevelManager activeLevelManager;
    public LevelManager ActiveLevelManager => activeLevelManager;

    

    private int levelCounter;
    
    private void Awake()
    {
        instance = this;
        SaveLoadBinary.LoadGame();
        if (SaveLoadBinary.instance.weaponUpgradeLevels == null)
        {
            SaveLoadBinary.instance.weaponUpgradeLevels = new int[weaponSelectionManager.WeaponsList.Count];
            for (int i = 0; i < SaveLoadBinary.instance.weaponUpgradeLevels.Length; i++)
            {
                SaveLoadBinary.instance.weaponUpgradeLevels[i] = 0;
            }
        }
        SaveLoadBinary.SaveGame();
        UIManager.InitiaterUIManager();
        weaponSelectionManager.InitiateWeaponSelection();
    }


    #region LevelOperations
    
    
    
    public void OnClickStartGame()
    {
        weaponSelectionManager.StartGamePressed();
        levelCounter = SaveLoadBinary.instance.activeLevelIndex;
        activeLevelManager = Instantiate(levelManagers[levelCounter], transform);
        activeLevelManager.InitiateLevelManager(this);
    }

    public void LevelEndedByGamePlay()
    {
        activeLevelManager.PlayerController.LevelEnd();
        UIManager.RevealHideWinScreen(true);
        SaveLoadBinary.SaveGame();
    }

    public void NextLevelInitiater()
    {
        SaveLoadBinary.instance.activeLevelIndex++;
        UIManager.InitiaterUIManager();
        UIManager.RevealHideWinScreen(false);
        weaponSelectionManager.InitiateWeaponSelection();
        Destroy(activeLevelManager.gameObject);
        SaveLoadBinary.SaveGame();
    }

    public void LevelEndedByFail()
    {
        activeLevelManager.PlayerController.LevelEnd();
        UIManager.RevealHideLoseScreen(true);
        SaveLoadBinary.SaveGame();
    }
    
    public void RetryLevelInitiater()
    {
        UIManager.InitiaterUIManager();
        UIManager.RevealHideWinScreen(false);
        weaponSelectionManager.InitiateWeaponSelection();
        Destroy(activeLevelManager.gameObject);
        SaveLoadBinary.SaveGame();
    }
    

    #endregion
    public void DoWeaponSelection(int weaponIndex)
    {
        weaponSelectionManager.DoWeaponSelection(weaponIndex);
    }

    #region MoneyOperations

    public bool IsMoneyEnoughtoBuy(float cost)
    {
        return cost <= SaveLoadBinary.instance.collectedMoney;
    }

    public void BuySomething(float cost)
    {
        SaveLoadBinary.instance.collectedMoney -= cost;
        SaveLoadBinary.SaveGame();
    }
    public void CollectMoney()
    {
        SaveLoadBinary.instance.collectedMoney += moneyGainAmount;
        UIManager.UICommonManager.Init();
        SaveLoadBinary.SaveGame();
    }

    #endregion
}

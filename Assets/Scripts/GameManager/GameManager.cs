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
        SaveLoadOperation();
        SaveLoadBinary.SaveGame();
        UIManager.InitiaterUIManager();
        weaponSelectionManager.InitiateWeaponSelection();
    }
    public void SaveLoadOperation()
    {
        if (SaveLoadBinary.instance.weaponUpgradeLevels == null)
        {
            SaveLoadBinary.instance.weaponUpgradeLevels = new int[weaponSelectionManager.WeaponsList.Count];
            for (int i = 0; i < SaveLoadBinary.instance.weaponUpgradeLevels.Length; i++)
            {
                SaveLoadBinary.instance.weaponUpgradeLevels[i] = 0;
            }
        }
        if (SaveLoadBinary.instance.isWeaponBought == null)
        {
            SaveLoadBinary.instance.isWeaponBought = new bool[weaponSelectionManager.WeaponsList.Count];
            for (int i = 0; i < SaveLoadBinary.instance.isWeaponBought.Length; i++)
            {
                SaveLoadBinary.instance.isWeaponBought[i] = false;
            }
            SaveLoadBinary.instance.isWeaponBought[0] = true;
        }

        for (int i = 0; i < SaveLoadBinary.instance.isWeaponBought.Length; i++)
        {
            if (SaveLoadBinary.instance.isWeaponBought[i])
            {
                weaponSelectionManager.WeaponsList[i].weaponCost = 0;
            }
        }
    }
    public void DoWeaponSelection(int weaponIndex)
    {
        weaponSelectionManager.DoWeaponSelection(weaponIndex);
    }
    #region LevelOperations
    
    public void OnClickStartGame()
    {
        weaponSelectionManager.StartGamePressed();
        levelCounter = SaveLoadBinary.instance.activeLevelIndex;
        activeLevelManager = Instantiate(levelManagers[levelCounter], transform);
        activeLevelManager.InitiateLevelManager(this);
    }


    public void LevelEndWithScreen(bool isWin)
    {
        if (isWin)
            UIManager.RevealHideWinScreen(true);
        else
            UIManager.RevealHideLoseScreen(true);
        activeLevelManager.PlayerController.LevelEnd();
        SaveLoadBinary.SaveGame();
    }

    public void NextOrRetryInitiater(bool isWin)
    {
        if (isWin)
        {
            UIManager.RevealHideWinScreen(false);
            SaveLoadBinary.instance.activeLevelIndex++;
        }
        else
            UIManager.RevealHideLoseScreen(false);
        UIManager.InitiaterUIManager();
        weaponSelectionManager.InitiateWeaponSelection();
        Destroy(activeLevelManager.gameObject);
        SaveLoadBinary.SaveGame();
    }

    #endregion
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

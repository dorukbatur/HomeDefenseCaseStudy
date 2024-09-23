using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager UIManager;
    public WeaponSelectionManager weaponSelectionManager;
    public List<LevelManager> levelManagers = new List<LevelManager>();
    
    private LevelManager activeLevelManager;
    private int tempActiveLevelIndex;
    
    private void Awake()
    {
        instance = this;
        SaveLoadBinary.LoadGame();
        if (SaveLoadBinary.instance.weaponUpgradeLevels == null)
        {
            SaveLoadBinary.instance.weaponUpgradeLevels = new float[weaponSelectionManager.WeaponsList.Count];
            for (int i = 0; i < SaveLoadBinary.instance.weaponUpgradeLevels.Length; i++)
            {
                SaveLoadBinary.instance.weaponUpgradeLevels[i] = 0;
            }
        }
        SaveLoadBinary.SaveGame();
        
        SaveLoadBinary.instance.collectedMoney = 100;
        UIManager.InitiaterUIManager();
        weaponSelectionManager.InitiateWeaponSelection();
    }
    
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

    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private WeaponSelectionManager weaponSelectionManager;
    [SerializeField] private List<LevelManager> levelManagers = new List<LevelManager>();
    
    private LevelManager activeLevelManager;
    private int tempActiveLevelIndex;
    
    private void Awake()
    {
        instance = this;
        SaveLoadBinary.LoadGame();
        UIManager.InitiaterUIManager();
        weaponSelectionManager.InitiateWeaponSelection();
    }

    private void Start()
    {
        //todo level check and instantiate level
    }
    
    
    
    //TODO WeaponSelectionOperations

    public void WeaponSelection(int weaponIndex)
    {
        SaveLoadBinary.instance.activeWeaponIndex = weaponIndex;
        SaveLoadBinary.SaveGame();
        weaponSelectionManager.SelectWeapon();
    }
    
}

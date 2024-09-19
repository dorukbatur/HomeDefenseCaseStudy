using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private Transform levelParent;
    
    [SerializeField] private List<LevelManager> levelManagers = new List<LevelManager>();
    
    private LevelManager activeLevelManager;
    private int activeLevelIndex;
    
    private void Awake()
    {
        instance = this;
        SaveLoadBinary.LoadGame();
        UIManager.InitiaterUIManager();
    }

    private void Start()
    {
        //todo level check and instantiate level
    }
    
}

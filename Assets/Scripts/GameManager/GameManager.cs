using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private List<LevelManager> levelManagers = new List<LevelManager>();
    private LevelManager activeLevelManager;
    private void Awake()
    {
        instance = this;
        if (SaveLoadBinary.instance == null)
        {
            SaveLoadBinary.LoadGame();
        }            
    }

    private void Start()
    {
        
    }
    
}

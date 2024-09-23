using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProceedManager : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;
    [SerializeField] private UpgradeBuyButton _upgradeBuyButton;

    public void Init()
    {
        _startButton.Init(this);
        _upgradeBuyButton.Init(this);
    }
    
    
    #region UpgradeButton

    public void UpdateUpgradeBuyButton()
    {
        
    }
    
    
    public void OnClickUpgradeBuyButton()
    {
        //todo upgrade operations
    }
    

    #endregion
    
    #region StartButton

    public void OnClickStartButton()
    {
        //TODO SUBLEVEL BAŞLICAK 
    }
    

    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProceedManager : MonoBehaviour
{
    private UISelectionManager manager;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private UpgradeBuyButton _upgradeBuyButton;

    public void Init(UISelectionManager manager)
    {
        this.manager = manager;
        _startButton.Init(this);
        _upgradeBuyButton.Init(this);
    }
    
    
    #region UpgradeButton

    public void UpdateUpgradeBuyButton(string text, bool isBought,bool isPurchasable)
    {
        _upgradeBuyButton.SetText(text, isBought, isPurchasable);
    }
    
    
    public void OnClickUpgradeBuyButton()
    {
        //todo upgrade operations
    }
    

    #endregion
    
    #region StartButton

    public void OnClickStartButton()
    {
        GameManager.instance.OnClickStartGame();
    }
    

    #endregion

}

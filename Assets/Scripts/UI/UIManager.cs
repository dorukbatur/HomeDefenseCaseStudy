using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UICommonManager UICommonManager;
    public UISelectionManager UISelectionManager;
    public UIShootingScreenManager UIShootingScreenManager;
    [SerializeField] private Transform winScreen, loseScreen;
    
    
    public void InitiaterUIManager()
    {
        instance = this;
        UICommonManager.Init();
        UISelectionManager.Init();
        UIShootingScreenManager.ActivationCrosshair(false);
    }

    public void RefreshStatesListItems(int index)
    {
        UISelectionManager.RefreshStatesListItems(index);
    }
    public void UpdateUpgradeBuyButton(string text, bool isBought,bool isPurchasable)
    {
        UISelectionManager.UpdateUpgradeBuyButton(text, isBought, isPurchasable);
    }

    public void ChooseStateOfListItem(int index)
    {
        UISelectionManager.ChooseStateOfListItem(index);
    }


    public void StartGamePressed()
    {
        UISelectionManager.StartGamePressed();
        UIShootingScreenManager.ActivationCrosshair(true);
    }


    #region WinLoseScreen

    public void RevealHideWinScreen(bool shouldBeShown)
    {
        winScreen.gameObject.SetActive(shouldBeShown);
    }
    public void RevealHideLoseScreen(bool shouldBeShown)
    {
        loseScreen.gameObject.SetActive(shouldBeShown);
    }
    
    
    //win winScreen, loseScreen
    
    public void WhenNextLevelButtonPressed()
    {
        GameManager.instance.NextOrRetryInitiater(true);
    }
    
    //lose
    
    public void WhenFailRetryButtonPressed()
    {
        GameManager.instance.NextOrRetryInitiater(false);
    }

    #endregion
    
}

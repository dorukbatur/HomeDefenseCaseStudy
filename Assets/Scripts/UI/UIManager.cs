using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UICommonManager UICommonManager;
    public UISelectionManager UISelectionManager;
    public UIShootingScreenManager UIShootingScreenManager;
    public void InitiaterUIManager()
    {
        instance = this;
        UICommonManager.Init();
        UISelectionManager.Init();
        UIShootingScreenManager.Init();
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
    }
}

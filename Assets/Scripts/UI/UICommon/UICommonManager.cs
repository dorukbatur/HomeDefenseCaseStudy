using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICommonManager : MonoBehaviour
{
    [SerializeField] private UICommonItem uiMoneyItem,uiLevelItem;
    
    public void Init()
    {
        uiMoneyItem.SetText(SaveLoadBinary.instance.collectedMoney + " $");
        uiLevelItem.SetText("Level: " + (SaveLoadBinary.instance.activeLevelIndex + 1));
    }
    
}

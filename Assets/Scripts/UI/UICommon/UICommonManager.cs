using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICommonManager : MonoBehaviour
{
    [SerializeField] private UICommonItem uiMoneyItem,uiLevelItem;
    
    //todo bağla bunu managera

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        uiMoneyItem.SetText("money"/*todo Money*/);
        uiLevelItem.SetText("level"/*todo level*/);
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private UICommonManager UICommonManager;
    [SerializeField] private UISelectionManager UISelectionManager;
    public void InitiaterUIManager()
    {
        instance = this;
        UICommonManager.Init();
        UISelectionManager.Init();
    }
}

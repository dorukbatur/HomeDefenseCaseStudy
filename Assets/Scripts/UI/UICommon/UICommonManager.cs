using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UICommonManager : MonoBehaviour
{
    [SerializeField] private UICommonItem uiMoneyItem,uiLevelItem;
    [SerializeField] private UIMoney uiMoneyParticle;
    
    public void Init()
    {
        uiMoneyItem.SetText(SaveLoadBinary.instance.collectedMoney + " $");
        uiLevelItem.SetText("Level: " + (SaveLoadBinary.instance.activeLevelIndex + 1));
    }

    public void MoneyParticleSpawner()
    {
        Instantiate(uiMoneyParticle, new Vector3(Random.Range(400f, 600f), Random.Range(700f, 1400f), 0f),//todo düzelt bunu
            Quaternion.identity,
            uiMoneyItem.transform);
    }
}

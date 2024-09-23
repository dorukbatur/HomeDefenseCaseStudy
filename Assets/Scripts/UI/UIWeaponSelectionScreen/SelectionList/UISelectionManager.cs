using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISelectionManager : MonoBehaviour
{
    [SerializeField] private ListItem listItemPrefab;
    [SerializeField] private Transform selectionLayoutParent;
    [SerializeField] private List<WeaponScriptableObject> weapons;
    [SerializeField] private UIProceedManager uiProceedManager;
    private List<ListItem> weaponListUIItems = new List<ListItem>();

    public void Init()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            ListItem item = Instantiate(listItemPrefab, Vector3.zero, Quaternion.identity, selectionLayoutParent);
            weaponListUIItems.Add(item);
            item.Init(this, weapons[i].menuScreenSprite, weapons[i].weaponCost.ToString());
        }
        RefreshStatesListItems(SaveLoadBinary.instance.activeWeaponIndex);
        uiProceedManager.Init(this);
    }

    public void OnClickListItem(ListItem listItem)
    {
        GameManager.instance.DoWeaponSelection(weaponListUIItems.IndexOf(listItem));
    }


    public void UpdateUpgradeBuyButton(string text, bool isBought,bool isPurchasable)
    {
        uiProceedManager.UpdateUpgradeBuyButton(text, isBought,isPurchasable);
    }

    public void RefreshStatesListItems(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
            weaponListUIItems[i].ChangeState(0, weapons[i].weaponCost == 0 ? "owned" : weapons[i].weaponCost.ToString());
        weaponListUIItems[index].ChangeState(2,"selected");
    }
    public void ChooseStateOfListItem(int index)
    {
        int activeWeaponIndex = SaveLoadBinary.instance.activeWeaponIndex;
        for (int i = 0; i < weapons.Count; i++)
            weaponListUIItems[i].ChangeState(0, weapons[i].weaponCost == 0 ? "owned" : weapons[i].weaponCost.ToString());
        weaponListUIItems[index].ChangeState(1,weapons[index].weaponCost.ToString());
        weaponListUIItems[activeWeaponIndex].ChangeState(2, "owned");
    }
    
}

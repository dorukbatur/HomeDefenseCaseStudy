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
        SelectAndChangeStatesListItems();
        uiProceedManager.Init();
    }

    public void OnClickListItem(ListItem listItem)
    {
        int weaponIndex = weaponListUIItems.IndexOf(listItem);
        GameManager.instance.WeaponSelection(weaponIndex);
        SelectAndChangeStatesListItems();
        //uiProceedManager.UpdateUpgradeBuyButton();
    }


    private void SelectAndChangeStatesListItems()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponListUIItems[i].ChangeState(0, weapons[i].weaponCost == 0 ? "owned" : weapons[i].weaponCost.ToString());
        }
        weaponListUIItems[SaveLoadBinary.instance.activeWeaponIndex].ChangeState(2,"selected");
    }
    
}

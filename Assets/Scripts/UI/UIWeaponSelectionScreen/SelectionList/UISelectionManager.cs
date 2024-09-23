using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionManager : MonoBehaviour
{
    [SerializeField] private ListItem listItemPrefab;
    [SerializeField] private Transform layoutParent;
    [SerializeField] private List<WeaponScriptableObject> weapons;
    private List<ListItem> weaponListUIItems = new List<ListItem>();

    private void Start()
    {
        InitUISelectionManager();
    }

    public void InitUISelectionManager()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            ListItem item = Instantiate(listItemPrefab, Vector3.zero, Quaternion.identity, layoutParent);
            weaponListUIItems.Add(item);
            item.Init(this, weapons[i].menuScreenSprite, weapons[i].weaponCost.ToString());
        }
        SelectAndChangeStatesListItems();
    }

    public void OnClickListItem(ListItem listItem)
    {
        int weaponIndex = weaponListUIItems.IndexOf(listItem);
        GameManager.instance.WeaponSelection(weaponIndex);
        SelectAndChangeStatesListItems();
    }


    private void SelectAndChangeStatesListItems()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponListUIItems[i].ChangeState(0, weapons[i].weaponCost.ToString());
        }
        weaponListUIItems[SaveLoadBinary.instance.activeWeaponIndex].ChangeState(2,"selected");
    }
    
    
}

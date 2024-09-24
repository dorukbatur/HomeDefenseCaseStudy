using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WeaponSelectionManager : MonoBehaviour
{
    [SerializeField] private Transform envParent, weaponSpawnParent;
    [SerializeField] private WeaponPositioner weaponPositioner;
    [SerializeField] private List<WeaponScriptableObject> weaponsList;
    private GameObject activeWeaponShown;

    public List<WeaponScriptableObject> WeaponsList => weaponsList;

    public void InitiateWeaponSelection()
    {
        DoWeaponSelection(SaveLoadBinary.instance.activeWeaponIndex);
    }
    private void Update()
    {
        weaponPositioner.Rotate();
    }
    
    public void DoWeaponSelection(int weaponIndex)
    {
        bool isPurchasable, isBought;
        string text;
        if (WeaponsList[weaponIndex].weaponCost == 0)//alınmışsa butonda update cost göster
        {
            SaveLoadBinary.instance.activeWeaponIndex = weaponIndex;
            UIManager.instance.RefreshStatesListItems(weaponIndex);
            float weaponsCalculatedUpgradeCost = (WeaponsList[weaponIndex].weaponUpgradeCost *
                                                  (SaveLoadBinary.instance.weaponUpgradeLevels[weaponIndex] + 1));
            isPurchasable = GameManager.instance.IsMoneyEnoughtoBuy(weaponsCalculatedUpgradeCost);
            isBought = true;
            text = weaponsCalculatedUpgradeCost.ToString();
        }
        else//alınmamışsa butonda silahın costunu göster
        {
            UIManager.instance.ChooseStateOfListItem(weaponIndex);
            isPurchasable = GameManager.instance.IsMoneyEnoughtoBuy(WeaponsList[weaponIndex].weaponCost);
            isBought = false;
            text = WeaponsList[weaponIndex].weaponCost.ToString();
        }
        
        UIManager.instance.UpdateUpgradeBuyButton(text + " $", isBought, isPurchasable);
        ShowWeapon(weaponIndex);
    }
    
    
    
    
    public void ShowWeapon(int index)
    {
        if (activeWeaponShown != null)
        {
            activeWeaponShown.transform.DOKill();
            activeWeaponShown.transform.localScale = Vector3.one;
            Destroy(activeWeaponShown);
        }
        activeWeaponShown = Instantiate(WeaponsList[index].prefab, weaponSpawnParent);
        activeWeaponShown.transform.localScale = Vector3.zero;
        activeWeaponShown.transform.DOScale(Vector3.one * 1.1f, 0.24f).OnComplete(() =>
        {
            activeWeaponShown.transform.DOScale(Vector3.one, 0.1f);
        });
    }

    public void StartGamePressed()
    {
        envParent.gameObject.SetActive(false);
        UIManager.instance.StartGamePressed();
    }
    
}

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

    public int SelectedWeaponIndex => selectedWeaponIndex;
    private int selectedWeaponIndex;

    public List<WeaponScriptableObject> WeaponsList => weaponsList;

    

    public void InitiateWeaponSelection()
    {
        envParent.gameObject.SetActive(true);
        DoWeaponSelection(SaveLoadBinary.instance.activeWeaponIndex);
    }
    private void Update()
    {
        weaponPositioner.Rotate();
    }
    
    public void DoWeaponSelection(int weaponIndex) //listeleme işlemi
    {
        bool isPurchasable, isBought;
        string text;
        if (WeaponsList[weaponIndex].weaponCost == 0)//silah satın alınmışsa upgradebuy butonda upgrade cost göster
        {
            SaveLoadBinary.instance.activeWeaponIndex = weaponIndex;
            UIManager.instance.RefreshStatesListItems(weaponIndex);
            float weaponsCalculatedUpgradeCost = (WeaponsList[weaponIndex].weaponUpgradeCost *
                                                  (SaveLoadBinary.instance.weaponUpgradeLevels[weaponIndex] + 1));
            isPurchasable = GameManager.instance.IsMoneyEnoughtoBuy(weaponsCalculatedUpgradeCost);
            if ((SaveLoadBinary.instance.weaponUpgradeLevels[weaponIndex] + 1) < 5)
                isPurchasable = false;
            isBought = true;
            text = weaponsCalculatedUpgradeCost.ToString();
        }
        else//silah satın alınmamışsa upgradebuy butonda silahın costunu göster
        {
            UIManager.instance.ChooseStateOfListItem(weaponIndex);
            isPurchasable = GameManager.instance.IsMoneyEnoughtoBuy(WeaponsList[weaponIndex].weaponCost);
            isBought = false;
            text = WeaponsList[weaponIndex].weaponCost.ToString();
        }
        selectedWeaponIndex = weaponIndex;
        UIManager.instance.UpdateUpgradeBuyButton(text + " $", isBought, isPurchasable);
        ShowWeapon(weaponIndex);
    }

    public void UpgradeBuyButtonIsPressed() // satınalma işlemi
    {
        float cost;
        if (WeaponsList[selectedWeaponIndex].weaponCost == 0)//silah satın alınmışsa upgradebuy butonda upgrade cost göster
        {
            //UIManager.instance.RefreshStatesListItems(selectedWeaponIndex);
            cost = (WeaponsList[selectedWeaponIndex].weaponUpgradeCost *
                          (SaveLoadBinary.instance.weaponUpgradeLevels[selectedWeaponIndex] + 1));
            if (GameManager.instance.IsMoneyEnoughtoBuy(cost))
            {
                GameManager.instance.BuySomething(cost);
                SaveLoadBinary.instance.weaponUpgradeLevels[selectedWeaponIndex]++;
                SaveLoadBinary.SaveGame();
            }
        }
        else//silah satın alınmamışsa upgradebuy butonda silahın costunu göster
        {
            cost = WeaponsList[selectedWeaponIndex].weaponCost;
            UIManager.instance.ChooseStateOfListItem(selectedWeaponIndex);
            if (GameManager.instance.IsMoneyEnoughtoBuy(cost))
            {
                GameManager.instance.BuySomething(cost);
                WeaponsList[selectedWeaponIndex].weaponCost = 0;
                SaveLoadBinary.instance.isWeaponBought[selectedWeaponIndex] = true;
                SaveLoadBinary.SaveGame();
            }
        }
        DoWeaponSelection(selectedWeaponIndex);
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

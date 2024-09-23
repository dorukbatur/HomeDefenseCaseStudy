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
    
    public void InitiateWeaponSelection()
    {
        ShowWeapon();
    }
    private void Update()
    {
        weaponPositioner.Rotate();
    }

    public void ShowWeapon()
    {
        if (activeWeaponShown != null)
        {
            activeWeaponShown.transform.DOKill();
            activeWeaponShown.transform.localScale = Vector3.one;
            Destroy(activeWeaponShown);
        }
        activeWeaponShown = Instantiate(weaponsList[SaveLoadBinary.instance.activeWeaponIndex].prefab, weaponSpawnParent);
        activeWeaponShown.transform.DOShakeScale(0.1f, Vector3.one * 0.4f, 1, 0f);
    }
    
}

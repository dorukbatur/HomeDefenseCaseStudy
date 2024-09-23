using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionManager : MonoBehaviour
{
    [SerializeField] private Transform envParent, weaponSpawnParent;
    [SerializeField] private WeaponPositioner weaponPositioner;
    [SerializeField] private List<WeaponScriptableObject> weaponsList;
    private GameObject activeWeaponShown;
    
    public void InitiateWeaponSelection()
    {
        SelectWeapon();
    }
    private void Update()
    {
        weaponPositioner.Rotate();
    }

    public void SelectWeapon()
    {
        if (activeWeaponShown != null)
            Destroy(activeWeaponShown);
        activeWeaponShown = Instantiate(weaponsList[SaveLoadBinary.instance.activeWeaponIndex].prefab, weaponSpawnParent);
    }
    
}

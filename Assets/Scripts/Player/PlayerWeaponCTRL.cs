using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCTRL : MonoBehaviour
{
    [SerializeField] private List<WeaponScriptableObject> weaponsScriptableObjects;
    [SerializeField] private RaycastCTRL _raycastCtrl;
    private GameObject activeWeaponShown;
    private WeaponScript activeWeaponScript;
    
    public void InitiaterWeaponCtrl()
    {
        ShowWeapon(SaveLoadBinary.instance.activeWeaponIndex);
    }

    private void Update()
    {
        if (_raycastCtrl.UpdateRaycastCTRL())
        {
            activeWeaponScript.FireGun();
        }
    }

    public void ShowWeapon(int index)
    {
        if (activeWeaponShown != null)
            Destroy(activeWeaponShown);
        activeWeaponShown = Instantiate(weaponsScriptableObjects[index].prefab, transform);
        activeWeaponScript = activeWeaponShown.GetComponentInChildren<WeaponScript>();
    }
    
}

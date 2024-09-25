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
    private int bulletDamage;
    private float timer = 1;
    
    public void InitiaterWeaponCtrl()
    {
        ShowWeapon(SaveLoadBinary.instance.activeWeaponIndex);
        _raycastCtrl.Init(this);
    }

    private void Update()
    {
        if (timer < 0)
        {
            timer = 1f;
            if (_raycastCtrl.UpdateRaycastCTRL())
            {
                activeWeaponScript.FireGun(bulletDamage);
            }
            return;
        }
        timer -= Time.deltaTime;
    }

    public void ShowWeapon(int index)
    {
        if (activeWeaponShown != null)
            Destroy(activeWeaponShown);
        activeWeaponShown = Instantiate(weaponsScriptableObjects[index].prefab, transform);
        bulletDamage = weaponsScriptableObjects[index].weaponDamage; //todo upgrade calculation index
        activeWeaponScript = activeWeaponShown.GetComponentInChildren<WeaponScript>();
    }
    
}

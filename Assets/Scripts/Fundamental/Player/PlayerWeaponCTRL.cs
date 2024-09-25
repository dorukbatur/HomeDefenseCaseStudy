using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCTRL : MonoBehaviour
{
    [SerializeField] private List<WeaponScriptableObject> weaponsScriptableObjects;
    [SerializeField] private RaycastCTRL _raycastCtrl;
    private WeaponScript activeWeaponScript;
    private int bulletDamage;
    private int ammoCapacity;
    private int ammoCount;
    private float timer = 1;
    
    public void InitiaterWeaponCtrl()
    {
        ShowWeapon(SaveLoadBinary.instance.activeWeaponIndex);
        ammoCapacity = weaponsScriptableObjects[SaveLoadBinary.instance.activeWeaponIndex].weaponAmmoCapacity;
        ammoCount = ammoCapacity;
        _raycastCtrl.Init(this);
    }

    private void Update()
    {
        if (timer < 0)
        {
            timer = 1f;
            if (_raycastCtrl.UpdateRaycastCTRL())
            {
                FireWeapon();
            }
            return;
        }
        timer -= Time.deltaTime;
    }

    public void ShowWeapon(int index)
    {
        if (activeWeaponScript)
            Destroy(activeWeaponScript.gameObject);
        activeWeaponScript = Instantiate(weaponsScriptableObjects[index].prefab, transform).GetComponent<WeaponScript>();
        bulletDamage = weaponsScriptableObjects[index].weaponDamage; //todo upgrade calculation index
    }

    public void FireWeapon()
    {
        if (ammoCount > 0)
        { 
            activeWeaponScript.FireGun(bulletDamage);
            ammoCount--;
            UIManager.instance.UIShootingScreenManager.UpdateAmmoCount(ammoCount.ToString());
        }
        //todo reload
    }
}

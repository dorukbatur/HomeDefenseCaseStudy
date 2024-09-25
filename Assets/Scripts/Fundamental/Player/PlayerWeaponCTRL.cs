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
    private bool isReloading = false;
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
        if (isReloading == true)
            return;
        if (timer < 0)
        {
            timer = 1f;//todo fire rate işlencek
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
            UpdateAmmoCountText();
        }
        if (ammoCount == 0)
        {
            isReloading = true;
            GameManager.instance.ActiveLevelManager.PlayerController.ReloadWeapon();
        }
    }

    public void ReloadWeaponComplete()
    {
        ammoCount = ammoCapacity;
        timer = 0f;
        UpdateAmmoCountText();
        isReloading = false;
    }

    private void UpdateAmmoCountText()
    {
        UIManager.instance.UIShootingScreenManager.UpdateAmmoCount(ammoCount.ToString());
    }
}

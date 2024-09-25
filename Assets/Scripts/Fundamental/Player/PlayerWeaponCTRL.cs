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
    private float fireRate = 1;
    
    
    
    public void InitiaterWeaponCtrl()
    {
        int index = SaveLoadBinary.instance.activeWeaponIndex;
        ammoCapacity = weaponsScriptableObjects[index].weaponAmmoCapacity +
                       weaponsScriptableObjects[index].weaponUpgradeAmmoCapacity *
                       SaveLoadBinary.instance.weaponUpgradeLevels[index];
        ammoCount = ammoCapacity;
        ShowWeapon(index);
        _raycastCtrl.Init(this);
    }

    private void FixedUpdate()
    {
        if (isReloading == true)
            return;
        if (timer < 0)
        {
            timer = fireRate;//todo fire rate işlencek
            if (_raycastCtrl.UpdateRaycastCTRL())
            {
                FireWeapon();
            }
            return;
        }
        timer -= Time.fixedDeltaTime;
    }

    public void ShowWeapon(int index)
    {
        if (activeWeaponScript)
            Destroy(activeWeaponScript.gameObject);
        activeWeaponScript = Instantiate(weaponsScriptableObjects[index].prefab, transform).GetComponent<WeaponScript>();
        
        fireRate = weaponsScriptableObjects[index].weaponFireRate +
                   weaponsScriptableObjects[index].weaponUpgradeFireRate *
                   SaveLoadBinary.instance.weaponUpgradeLevels[index];
        fireRate = 60 / fireRate;// dakikada 200 ise 1 atım arası kaç saniye hesaplaması 60sn/firePerMin
        bulletDamage = weaponsScriptableObjects[index].weaponDamage +
                       weaponsScriptableObjects[index].weaponUpgradeDamage *
                       SaveLoadBinary.instance.weaponUpgradeLevels[index];
    }

    public void FireWeapon()
    {
        if (ammoCount > 0)
        { 
            activeWeaponScript.FireGun(bulletDamage);
            ammoCount--;
            UpdateAmmoCountText();
            GameManager.instance.ActiveLevelManager.PlayerController.FireAnimateWeapon();
        }
        if (ammoCount == 0)
        {
            isReloading = true;
            timer = 1f;
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

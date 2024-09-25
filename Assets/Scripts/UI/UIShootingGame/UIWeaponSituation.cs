using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponSituation : MonoBehaviour
{
    [SerializeField] private List<WeaponScriptableObject> weaponScriptableObjects;
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI ammoCountTextStatic;
    [SerializeField] private TextMeshProUGUI ammoCountTextDynamic;
    private string initStaticAmmoText;
    public void Init()
    {
        weaponImage.sprite = weaponScriptableObjects[SaveLoadBinary.instance.activeWeaponIndex].gameScreenSprite;
        string weaponAmmoCapacity = weaponScriptableObjects[SaveLoadBinary.instance.activeWeaponIndex].weaponAmmoCapacity.ToString();
        initStaticAmmoText = weaponAmmoCapacity;
        UpdateAmmoCount(weaponAmmoCapacity);
    }

    public void UpdateAmmoCount(string text)
    {
        ammoCountTextStatic.text = initStaticAmmoText;
        ammoCountTextDynamic.text = text;
    }
}

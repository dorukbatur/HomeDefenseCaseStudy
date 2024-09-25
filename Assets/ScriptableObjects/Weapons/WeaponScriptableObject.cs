using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    public float weaponCost;
    public float weaponUpgradeCost;
    public int weaponDamage;
    public float weaponFireRate;
    public int weaponAmmoCapacity;
    public Sprite gameScreenSprite;
    public Sprite menuScreenSprite;
    public GameObject prefab;
}

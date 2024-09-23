using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    public float weaponCost;
    public int weaponDamage;
    public float weaponFireRate;
    public int weaponAmmoCapacity;
    public Sprite menuScreenSprite;
    public GameObject prefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    public void ReloadEvent()
    {
        GameManager.instance.ActiveLevelManager.PlayerController.SetIKDependsOnWeaponType();
    }
}

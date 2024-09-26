using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCTRL : MonoBehaviour
{

    private float sensivity = 400;
    [SerializeField] private Transform rotationRoot;
    [SerializeField] private PlayerWeaponCTRL weaponCtrl;
    [SerializeField] private RigBuilder _rigBuilder;
    [SerializeField] private Animator animationCtrl;
    private static int FireTrigger = Animator.StringToHash("FireTrigger");
    private static int ReloadTrigger = Animator.StringToHash("ReloadTrigger");
    private float xRotation = 0f, yRotation = 0f;
    private float Yclamp = 90f;
    private float Xclamp = 45f;
    private bool endLevelBool = false;

    public void InitPlayerCTRL(Transform walkToThisPos)
    {
        //SetIKDependsOnWeaponType();
        Cursor.lockState = CursorLockMode.Locked;
        weaponCtrl.InitiaterWeaponCtrl();
        StartCoroutine(MoveThePlayerToGamePos(walkToThisPos));
    }
    
    public void LevelEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        endLevelBool = true;
    }

    IEnumerator MoveThePlayerToGamePos(Transform walkToThisPos)
    {
        var wait = new WaitForEndOfFrame();
        float timer = 0f, delay = 2f;
        Vector3 startPos = transform.position;
        Vector3 startRot = transform.forward;
        while (timer < delay)
        {
            transform.position = Vector3.Lerp(startPos, walkToThisPos.position, timer / delay);
            transform.forward = Vector3.Lerp(startRot, walkToThisPos.forward, timer / delay);
            timer += Time.deltaTime;
            yield return wait;
        }
    }

    private void Update()
    {
        if (endLevelBool)
            return;
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -Yclamp, Yclamp);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -Xclamp, Xclamp);

        rotationRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }


    public void ReloadWeapon()
    {
        SetIKDisabled();
        DoReloadAnimation();
    }

    public void SetIKDependsOnWeaponType()
    {
        SetIKDisabled();
        StartCoroutine(RigWeightResetter());
    }

    IEnumerator RigWeightResetter()
    {
        var wait = new WaitForEndOfFrame();
        float timer = 0;
        float delay = 0.40f;
        while (timer < delay)
        {
            _rigBuilder.layers[SaveLoadBinary.instance.activeWeaponIndex].rig.weight = timer / delay;
            timer += Time.deltaTime;
            yield return wait;
        }
        _rigBuilder.layers[SaveLoadBinary.instance.activeWeaponIndex].rig.weight = 1;
        weaponCtrl.ReloadWeaponComplete();
    }

    private void SetIKDisabled()
    {
        foreach (RigLayer layer in _rigBuilder.layers)
            layer.rig.weight = 0;
    }

    #region WeaponAnimation

    public void DoReloadAnimation()
    {
        animationCtrl.SetTrigger(ReloadTrigger);
    }
    public void FireAnimateWeapon()
    {
        animationCtrl.SetTrigger(FireTrigger);
    }
    #endregion

    
}

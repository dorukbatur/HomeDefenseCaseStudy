using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{

    private float sensivity = 400;
    [SerializeField] private Transform rotationRoot;
    [SerializeField] private PlayerWeaponCTRL weaponCtrl;

    private float xRotation = 0f, yRotation = 0f;
    private float clamp = 90f;
    
    public void InitPlayerCTRL()
    {
        Cursor.lockState = CursorLockMode.Locked;
        weaponCtrl.InitiaterWeaponCtrl();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clamp, clamp);

        yRotation += mouseX;

        rotationRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
        
    }


    //todo fps, raycast, ik
}

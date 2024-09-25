using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{

    private float sensivity = 400;
    [SerializeField] private Transform rotationRoot;
    [SerializeField] private PlayerWeaponCTRL weaponCtrl;
    [SerializeField] private CinemachineVirtualCamera camera;
    public CinemachineVirtualCamera Camera => camera;

    private float xRotation = 0f, yRotation = 0f;
    private float Yclamp = 90f;
    private float Xclamp = 45f;


    public void InitPlayerCTRL(Transform walkToThisPos)
    {
        Cursor.lockState = CursorLockMode.Locked;
        weaponCtrl.InitiaterWeaponCtrl();
        StartCoroutine(MoveThePlayerToGamePos(walkToThisPos));
    }

    IEnumerator MoveThePlayerToGamePos(Transform walkToThisPos)
    {
        
        var wait = new WaitForEndOfFrame();
        float timer = 0f, delay = 1f;
        Vector3 startPos = transform.position;
        Vector3 startRot = transform.forward;
        while (timer < delay)
        {
            transform.position = Vector3.Lerp(startPos, walkToThisPos.position, timer / delay);
            transform.forward = Vector3.Lerp(startRot, walkToThisPos.forward, timer * 5f / delay);
            
            timer += Time.deltaTime;
            yield return wait;
        }
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -Yclamp, Yclamp);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -Xclamp, Xclamp);

        rotationRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}

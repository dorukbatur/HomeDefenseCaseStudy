using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RaycastCTRL : MonoBehaviour
{

    [SerializeField] private LayerMask layer;
    private PlayerWeaponCTRL parentCtrl;


    public void Init(PlayerWeaponCTRL parentCtrl)
    {
        this.parentCtrl = parentCtrl;
    }
    public bool UpdateRaycastCTRL()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 50f, layer))
        {
            if (hitInfo.transform.GetComponent<IDamageable>() != null)
            {
                parentCtrl.transform.forward = Vector3.Normalize(hitInfo.point - parentCtrl.transform.position);
                return true;
            }
        }
        return false;
    }
}

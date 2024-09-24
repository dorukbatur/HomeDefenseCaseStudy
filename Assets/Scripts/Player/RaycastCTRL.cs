using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RaycastCTRL : MonoBehaviour
{


    public bool UpdateRaycastCTRL()
    {
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo,20f))
        {
            if (hitInfo isShootable)
            {
                return true;
            }
        }*/
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPositioner : MonoBehaviour
{
    [SerializeField] private float rotater; 
    [SerializeField] private Transform rotatePosition; 
    
    public void Rotate()
    {
        rotatePosition.Rotate(0, rotater, 0);
    }
}

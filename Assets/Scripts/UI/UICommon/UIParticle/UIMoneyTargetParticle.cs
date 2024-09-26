using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoneyTargetParticle : MonoBehaviour
{
    public static UIMoneyTargetParticle instance;

    private void Awake()
    {
        instance = this;
    }
}

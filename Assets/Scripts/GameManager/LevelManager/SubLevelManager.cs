using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelManager : MonoBehaviour
{
    private LevelManager parentLevelManager;
    //todo enemy 
    public void InitiateSubLevelManager(LevelManager parentLevelManager)
    {
        this.parentLevelManager = parentLevelManager;
    }
}

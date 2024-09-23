using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private UIProceedManager manager;

    public void Init(UIProceedManager manager)
    {
        this.manager = manager;
    }

    public void OnClickStartButton()
    {
        manager.OnClickStartButton();
    }
}

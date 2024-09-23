using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeBuyButton : MonoBehaviour
{
    private UIProceedManager manager;
    [SerializeField] private TextMeshProUGUI costText, buttonText;
    [SerializeField] private Transform uiDisabledBorderImagesTransform;
    

    public void Init(UIProceedManager manager)
    {
        this.manager = manager;
    }

    public void SetText(string text, bool isTrue)
    {
        //todo
        costText.text = text;
        buttonText.text = isTrue ? "Upgrade" : "Buy";
    }
    
    public void OnClickUpgradeBuyButton()
    {
        manager.OnClickUpgradeBuyButton();
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    
    public void SetText(string text, bool isBought,bool isPurchasable)
    {
        buttonText.transform.DOKill();
        buttonText.transform.localScale = Vector3.one;
        costText.text = text;
        buttonText.text = isBought ? "Upgrade" : "Buy";
        buttonText.color = !isPurchasable ? Color.white : Color.yellow;
        if (isPurchasable)
        {
            TextTweenAnimation();
        }
        uiDisabledBorderImagesTransform.gameObject.SetActive(!isPurchasable);
    }

    private void TextTweenAnimation()
    {
        buttonText.transform.DOScale(Vector3.one * 1.1f, 1f).OnComplete(() =>
        {
            buttonText.transform.DOScale(Vector3.one * 1f, 1f).OnComplete(() =>
            {
                TextTweenAnimation();//TODO kafamda ciddi rikörsif sorular
            });
        });
    }
    
    public void OnClickUpgradeBuyButton()
    {
        manager.OnClickUpgradeBuyButton();
    }
}

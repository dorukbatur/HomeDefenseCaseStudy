using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIInfoGraphicManager : MonoBehaviour
{
    [SerializeField] private Transform shakeTransform;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI damageTextUpgrade;
    [SerializeField] private TextMeshProUGUI fireRateText;
    [SerializeField] private TextMeshProUGUI fireRateTextUpgrade;
    [SerializeField] private TextMeshProUGUI ammoCapacityText;
    [SerializeField] private TextMeshProUGUI ammoCapacityTextUpgrade;

    public void Init(string damageText, string damageTextUpgrade, string fireRateText, string fireRateTextUpgrade, string ammoCapacityText, string ammoCapacityTextUpgrade)
    {
        this.damageText.text = damageText;
        this.damageTextUpgrade.text = damageTextUpgrade;
        this.fireRateText.text = fireRateText;
        this.fireRateTextUpgrade.text = fireRateTextUpgrade;
        this.ammoCapacityText.text = ammoCapacityText;
        this.ammoCapacityTextUpgrade.text = ammoCapacityTextUpgrade;
        ShakeUI();
    }

    public void ShakeUI()
    {
        shakeTransform.DOKill();
        shakeTransform.localScale = Vector3.one;
        shakeTransform.DOScale(Vector3.one * 1.1f, 0.1f).OnComplete(() =>
        {
            shakeTransform.DOScale(Vector3.one, 0.1f);
        });
    }
    
    public void OpenCloseTexts(bool shouldBeShown)
    {
        damageTextUpgrade.gameObject.SetActive(shouldBeShown);
        fireRateTextUpgrade.gameObject.SetActive(shouldBeShown);
        ammoCapacityTextUpgrade.gameObject.SetActive(shouldBeShown);
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIShootingScreenManager : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Image shootingFeedback;
    private Color red = Color.red;


    public void ActivationCrosshair(bool shouldActivate)
    {
        parent.gameObject.SetActive(shouldActivate);
    }

    public void GiveShootFeedback()
    {
        shootingFeedback.color = red;
        shootingFeedback.DOKill();
        shootingFeedback.DOFade(0, 1f).SetDelay(0.25f);
    }
}

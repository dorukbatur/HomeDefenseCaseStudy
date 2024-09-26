using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    
    private void Start()
    {
        transform.DOScale(Vector3.one, 1f).OnComplete(() =>
        {
            transform.DOMove(UIMoneyTargetParticle.instance.transform.position, 1f).OnComplete(() =>
            {
                GameManager.instance.CollectMoney();
                Destroy(gameObject, 0.1f);
            });
        });
    }
}

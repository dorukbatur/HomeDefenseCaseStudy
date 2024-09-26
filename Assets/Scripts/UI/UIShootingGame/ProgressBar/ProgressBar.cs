using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillerImage;

    public void Init()
    {
        fillerImage.fillAmount = 0;
    }

    public void UpdateFillerImage(float division)
    {
        fillerImage.fillAmount = division;
    }
}

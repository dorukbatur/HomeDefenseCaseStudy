using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICommonItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI commonItemText;
    
    public void SetText(string text)
    {
        commonItemText.text = text;
    }
}

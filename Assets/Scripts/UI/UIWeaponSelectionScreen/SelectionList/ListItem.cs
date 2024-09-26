using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ListItem : MonoBehaviour
{
    [SerializeField] private List<Transform> selectionImages;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI listItemText;
    
    private UISelectionManager parent;
    private int selectionState = 0;

    public void Init(UISelectionManager parent, Sprite sprite, string text)
    {
        this.parent = parent;
        SetImage(sprite);
        ChangeState(0,text);
    }
    
    public void ButtonPressed()
    {
        parent.OnClickListItem(this);
    }
    
    public void SetImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }
    
    public void SetText(string text)
    {
        listItemText.text = text;
    }
    
    public void ChangeState(int State, string text)
    {
        selectionState = State;
        ChangeBorderByState();
        SetText(text);
    }

    private void ChangeBorderByState()
    {
        foreach (Transform imgs in selectionImages)
        {
            imgs.gameObject.SetActive(false);
        }
        selectionImages[selectionState].gameObject.SetActive(true);
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionManager : MonoBehaviour
{
    [SerializeField] private ListItem listItemPrefab;
    [SerializeField] private Transform layoutParent;
    [SerializeField] private List<Sprite> weaponImages;
    private List<ListItem> weaponListUIItems = new List<ListItem>();

    private void Start()
    {
        InitUISelectionManager();
    }

    public void InitUISelectionManager()
    {
        for (int i = 0; i < 3; i++)
        {
            ListItem item = Instantiate(listItemPrefab, Vector3.zero, Quaternion.identity, layoutParent);
            weaponListUIItems.Add(item);
            item.Init(this, weaponImages[i], i.ToString());
        }
    }

    public void OnClickListItem(ListItem listItem)
    {
        foreach (ListItem item in weaponListUIItems)
        {
            item.ChangeState(0, "0");
        }
        listItem.ChangeState(2,"selected");
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private Image amountContainer;
    [SerializeField] private TextMeshProUGUI amountItem;
    
    public static event Action<int> OnSeletedSlot;


    public int Index { get; set; }

    public void UpdateSlot(Items item) {
        iconItem.sprite = item.icon;
        amountItem.text = item.amountItem.ToString();
    }


    public void ShowInforItemInSlot(bool value)
    {
        iconItem.gameObject.SetActive(value);
        amountContainer.gameObject.SetActive(value);
    }

    public void ClickToSelectSlot()
    {
        OnSeletedSlot?.Invoke(Index);  
    }
}

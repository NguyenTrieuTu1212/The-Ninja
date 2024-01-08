using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private Image amountContainer;
    [SerializeField] private TextMeshProUGUI amountItem;
    

    public int Index { get; set; }

    public void UpdateSlot(InventoryItem item) {
        iconItem.sprite = item.icon;
        amountItem.text = item.amountItem.ToString();
    }


    public void ShowInforItemInSlot(bool value)
    {
        iconItem.gameObject.SetActive(value);
        amountContainer.gameObject.SetActive(value);
    }

}

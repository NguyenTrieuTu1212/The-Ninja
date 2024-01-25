using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : Singleton<InventoryUI>
{
    [Header ("Config Slot in Inventory")]
    [SerializeField] private InventorySlots slotPrefab;
    [SerializeField] private Transform containerSlot;
    private List<InventorySlots> slotsList= new List<InventorySlots>();


    [Header("Config panel inventory")]
    [SerializeField] private GameObject inventoryPanel;


    [Header("Config decription item")]
    [SerializeField] private GameObject decriptionPanel;
    [SerializeField] private Image imageItemDetail;
    [SerializeField] private TextMeshProUGUI nameItem_TMP;
    [SerializeField] private TextMeshProUGUI detailItem_TMP;

    public void InitInventory()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlots slot = Instantiate(slotPrefab, containerSlot);
            slot.Index = i;
            slot.ShowInforItemInSlot(false);
            slotsList.Add(slot);
        }
    }


    public void DrawSlot(Items item,int indexSlot) 
    {
        InventorySlots slot = slotsList[indexSlot];
        if(item == null)
        {
            slot.ShowInforItemInSlot(false);
            return;
        }
        slot.ShowInforItemInSlot(true);
        slot.UpdateSlot(item);

    }


    public void ShowDecriptionItem(Items item,bool isDisplay)
    {
        if (isDisplay)
        {
            imageItemDetail.sprite = item.icon;
            nameItem_TMP.text = item.nameItem;
            detailItem_TMP.text = item.description;
        }
        decriptionPanel.SetActive(isDisplay);
    }

    public void OpenAndCloseInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf == true)
        {
            decriptionPanel.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] private InventorySlots slotPrefab;
    [SerializeField] private Transform containerSlot;
    private List<InventorySlots> slotsList= new List<InventorySlots>();


    private void Start()
    {
        InitInventory();
    }


    private void InitInventory()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlots slot = Instantiate(slotPrefab, containerSlot);
            slot.Index = i;
            slotsList.Add(slot);
        }
    }


    public void DrawSlot(Items item,int indexSlot) 
    {
        InventorySlots slot = slotsList[indexSlot]; 
        slot.UpdateSlot(item);
        slot.ShowInforItemInSlot(true);

    }
}

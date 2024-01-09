using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private InventoryItem itemTest;
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryItem[] items;

    public int InventorySize => inventorySize;


    protected override void Awake()
    {
        base.Awake();
        items = new InventoryItem[inventorySize];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            items[0] = itemTest.CopyItem();
            items[0].amountItem = 20;
            InventoryUI.Instance.DrawSlot(items[0], 0);
        }
    }

    private void AddItem(InventoryItem item,int amount)
    {
        item.amountItem += amount;
    }
    


    
}

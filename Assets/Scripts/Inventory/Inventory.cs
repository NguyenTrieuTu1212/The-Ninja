using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private Items itemTest;
    [SerializeField] private int inventorySize;
    [SerializeField] private Items[] inventoryItems;

    public int InventorySize => inventorySize;


    protected override void Awake()
    {
        base.Awake();
        inventoryItems = new Items[inventorySize];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddItem(itemTest, 5);
        }
        
    }

    private void AddItem(Items item,int amount)
    {
        
        if (item == null || amount <= 0) return;
        List<int> itemsIndexes = CheckItemStock(item.ID);
        if (item.isStackable && itemsIndexes.Count > 0)
        {
            for (int i = 0; i < itemsIndexes.Count; i++)
            {
                int maxStack = item.maxStack;
                if (inventoryItems[i].amountItem < maxStack)
                {
                    inventoryItems[i].amountItem += amount;
                    if (inventoryItems[i].amountItem > maxStack)
                    {
                        int dif = inventoryItems[i].amountItem - maxStack;
                        inventoryItems[i].amountItem = maxStack;
                        AddItem(item, dif);
                    }
                    InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                    return;
                }
            }
        }
        int amountAdd = amount > item.maxStack ? item.maxStack : amount;
        AddItemsInFreeSlot(item, amountAdd);
        int remainder = amount - amountAdd;
        if(remainder > 0)
        {
            AddItem(item, remainder);   
        }

    }



    private void AddItemsInFreeSlot(Items item,int amount)
    {
        for(int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] != null) continue;
            inventoryItems[i] = item.CopyItem();
            inventoryItems[i].amountItem = amount;
            InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
            return;
        }
    }


    private List<int> CheckItemStock(string ID)
    {
        List<int> result = new List<int>();
        for(int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null) continue;
            if(inventoryItems[i].ID == ID) result.Add(i);
        }
        return result;
    }

}

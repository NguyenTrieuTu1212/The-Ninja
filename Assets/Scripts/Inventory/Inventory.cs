using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private Items itemTest;
    [SerializeField] private int inventorySize;
    [SerializeField] private Items[] items;

    public int InventorySize => inventorySize;


    protected override void Awake()
    {
        base.Awake();
        items = new Items[inventorySize];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            /*items[0] = itemTest.CopyItem();
            items[0].amountItem = 20;
            InventoryUI.Instance.DrawSlot(items[0], 0);*/
            
            AddItem(itemTest, 5);


        }
        
    }


    private void AddItem(Items item, int amount)
    {
        List<int> stocks = CheckItemsStock(item.ID);
        if(item.isStackable || stocks.Count > 0)
        {
            foreach(int iStock in stocks)
            {
                int maxStack = items[iStock].maxStack;
                if(items[iStock].amountItem < maxStack)
                {
                    items[iStock].amountItem += amount;
                    if(items[iStock].amountItem > maxStack)
                    {
                        int dif = items[iStock].amountItem - maxStack;
                    }
                }
            }
        }
    }

    private void AddItemInFreeSlot(Items item,int amount)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null) continue;
            if (items[i] == null)
            {
                items[i] = itemTest.CopyItem();
                items[i].amountItem = amount;
                return;
            }
        }
    }

    private List<int> CheckItemsStock(string idItem)
    {
        List<int> indexes = new List<int>();
        
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) continue;
            if (items[i].ID == idItem) indexes.Add(i);
        }
        return indexes;
    }
       
}

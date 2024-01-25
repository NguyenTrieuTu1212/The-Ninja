using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using System;

public class Inventory : Singleton<Inventory>
{
    
    [SerializeField] private Items itemTest;
    [SerializeField] private Database database;
    [SerializeField] private int inventorySize;
    [SerializeField] private Items[] inventoryItems;
    private readonly string KEY_DATA = "SAVE_GAME";

    /* public static event Action<string> OnUseItem;*/


    public int InventorySize => inventorySize;


    public int indexCurrentItem { get;  set; }

    protected override void Awake()
    {
        base.Awake();
        inventoryItems = new Items[inventorySize];
    }

    


    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddItem(itemTest, 1);
        }
        
    }




    // Load inventory
    /*public void LoadGame(GameData gameData)
    {
        dataItems = gameData.inventoryData;
        for (int i = 0; i < inventorySize; i++)
        {
            if (dataItems.itemID[i] != null)
            {
                Items itemSaved = FindSavedItems(dataItems.itemID[i]);
                if (itemSaved != null)
                {
                    Debug.Log("Item saved ID: " + itemSaved.ID);
                    inventoryItems[i] = itemSaved.CopyItem();
                    inventoryItems[i].amountItem = itemSaved.amountItem;
                    InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                }
            }
        }




    }

    // Save inventory
    public void SaveGame(ref GameData gameData)
    {
        gameData.inventoryData = dataItems;
        dataItems.itemID = new String[InventorySize];
        dataItems.itemAmount = new int[InventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                dataItems.itemID[i] = null;
                dataItems.itemAmount[i] = 0;
            }
            else
            {
                dataItems.itemID[i] = inventoryItems[i].ID;
                dataItems.itemAmount[i] = inventoryItems[i].amountItem;
            }
        }
        gameData.inventoryData = dataItems;
    }*/

    private Items FindSavedItems(string itemId)
    {
        for(int i = 0; i < inventorySize; i++)
        {
            if(database.listItems[i].ID == itemId) return database.listItems[i];
        }
        return null;
    }

    /*private void LoadDataItem()
    {
        if (SaveGame.Exists(KEY_DATA))
        {
            InventoryData loadData = SaveGame.Load<InventoryData>(KEY_DATA);
            for (int i = 0; i < inventorySize; i++)
            {
                if (loadData.itemID[i] != null)
                {
                    Items itemSaved = FindSavedItems(loadData.itemID[i]);
                    if (itemSaved != null)
                    {
                        inventoryItems[i] = itemSaved.CopyItem();
                        inventoryItems[i].amountItem = loadData.itemAmount[i];
                        InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                    }
                }
                else
                {
                    inventoryItems[i] = null;
                }
            }
        }
    }*/

    private void SaveDataItem()
    {
        InventoryData dataItems = new InventoryData();
        dataItems.itemID = new String[inventorySize];
        dataItems.itemAmount = new int[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                dataItems.itemID[i] = null;
                dataItems.itemAmount[i] = 0;
            }
            else
            {
                dataItems.itemID[i] = inventoryItems[i].ID;
                dataItems.itemAmount[i] = inventoryItems[i].amountItem;
            }
        }
        SaveGame.Save(KEY_DATA, dataItems);
    }

    private void AddItem(Items item, int amount)
    {
        if (item == null || amount <= 0) return;
        List<int> itemIdexes = FindItemsStock(item.ID);
        if(item.isStackable && itemIdexes.Count > 0)
        {
            foreach(int index in itemIdexes)
            {
                int maxStack = item.maxStack;
                int spaceAvailable = maxStack - inventoryItems[index].amountItem;
                if(spaceAvailable > 0)
                {
                    int amountToAdd = Mathf.Min(spaceAvailable, amount);
                    inventoryItems[index].amountItem += amountToAdd;
                    InventoryUI.Instance.DrawSlot(inventoryItems[index], index);
                    amount -= amountToAdd;
                    if (amount <= 0)
                    {
                        SaveDataItem();
                        return;
                    }
                }
            }
        }
        SaveDataItem();
        AddItemInFreeSlot(item, amount);
        
    }


    private void AddItemInFreeSlot(Items item,int amount)
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
    
    private List<int> FindItemsStock(string ID)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < inventorySize;i++)
        {
            if (inventoryItems[i] == null) continue;
            if(inventoryItems[i].ID == ID) result.Add(i);
        }

        return result;
    }


    public void UseItem()
    {

        if (inventoryItems[indexCurrentItem] == null || inventoryItems[indexCurrentItem].type == ItemsType.Weapon)
        {
            Debug.Log("Item is null !!! Not used !!!!");
            return;
        }
        if (inventoryItems[indexCurrentItem].UseItem())
        {
            DegreeItem(indexCurrentItem);
            if (inventoryItems[indexCurrentItem] == null) return;
            AnimationManager.Instance.PlayAnimation(inventoryItems[indexCurrentItem].ID);
            Debug.Log("Item used in inventory !!!!!");
        }
        SaveDataItem();
    }


    public void EquipItem()
    {
        if(inventoryItems[indexCurrentItem] == null) return;
        if (inventoryItems[indexCurrentItem].type != ItemsType.Weapon) return;
        inventoryItems[indexCurrentItem].EquipItem();

    }


    public void RemoveItem()
    {
        if(inventoryItems[indexCurrentItem] == null) return;
        inventoryItems[indexCurrentItem].RemoveItem();
        inventoryItems[indexCurrentItem] = null;
        InventoryUI.Instance.DrawSlot(null, indexCurrentItem);
        SaveDataItem();
    }



    private void DegreeItem(int index)
    {
        if (inventoryItems[index] == null) return;
        inventoryItems[index].amountItem--;
        if (inventoryItems[index].amountItem <= 0)
        {
            inventoryItems[index] = null;
            InventoryUI.Instance.DrawSlot(inventoryItems[index], index);
        }
        else
        {
            InventoryUI.Instance.DrawSlot(inventoryItems[index], index);
        }
    }


    private void SeletedSlotCallBack(int index)
    {
        indexCurrentItem = index;
        if(inventoryItems[indexCurrentItem] == null)
        {
            InventoryUI.Instance.ShowDecriptionItem(null, false);
            return;
        }
        InventoryUI.Instance.ShowDecriptionItem(inventoryItems[indexCurrentItem],true);
        Debug.Log("Get current index is: " + indexCurrentItem.ToString());    
    }

    

    private void OnEnable()
    {
        InventorySlots.OnSeletedSlot += SeletedSlotCallBack;
    }


    private void OnDisable()
    {
        InventorySlots.OnSeletedSlot -= SeletedSlotCallBack;
    }

}

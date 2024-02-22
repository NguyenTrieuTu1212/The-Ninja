using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using System;

public class Inventory : Singleton<Inventory>,IDataPersistance
{
    
    [SerializeField] private Items itemTest;
    [SerializeField] private Database database;
    [SerializeField] private int inventorySize;
    [SerializeField] private Items[] inventoryItems;
    /*private readonly string KEY_DATA = "Mykey";*/
    private InventoryData data;
    public int InventorySize => inventorySize;
    public int indexCurrentItem { get;  set; }

    /*private void Start()
    {
        inventoryItems = new Items[inventorySize];
        InventoryUI.Instance.InitInventory();
        VerifyToDrawItems();
        LoadDataItems();
    }*/




    public void LoadGame(GameData gameData)
    {
        inventoryItems = new Items[inventorySize];
        InventoryUI.Instance.InitInventory();
        VerifyToDrawItems();
        LoadDataItems(gameData);
    }


    public void SaveGame(ref GameData gameData)
    {

        data.itemID = new string[inventorySize];
        data.itemAmount = new int[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                data.itemID[i] = "";
                data.itemAmount[i] = 0;
            }
            else
            {
                data.itemID[i] = inventoryItems[i].ID;
                data.itemAmount[i] = inventoryItems[i].amountItem;
            }
        }
        gameData.inventoryData = data;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddItem(itemTest, 1);
        }
        
    }

    private void LoadDataItems(GameData dataItems)
    {
        /*data = dataItems.inventoryData;
        data.itemID = dataItems.inventoryData.itemID;
        data.itemAmount = dataItems.inventoryData.itemAmount;
        for (int i = 0; i < inventorySize; i++)
        {
            if (data.itemID[i] != null)
            {
                Items itemSaved = FindSavedItems(data.itemID[i]);
                if (itemSaved != null)
                {
                    inventoryItems[i] = itemSaved.CopyItem();
                    inventoryItems[i].amountItem = data.itemAmount[i];
                    InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                }
            }
            else
            {
                inventoryItems[i] = null;
            }
        }*/
        if(dataItems.inventoryData != null)
        {
            data = dataItems.inventoryData;
            if(data.itemID != null && data.itemAmount != null)
            {
                for (int i = 0; i < inventorySize; i++)
                {
                    if (data.itemID[i] != null)
                    {
                        Items itemSaved = FindSavedItems(data.itemID[i]);
                        if (itemSaved != null)
                        {
                            inventoryItems[i] = itemSaved.CopyItem();
                            inventoryItems[i].amountItem = data.itemAmount[i];
                            InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                        }
                    }
                    else
                    {
                        inventoryItems[i] = null;
                    }
                }
            }
        }  
    }


    // ================================= Save and Load data in another way (Applicable) =======================================
    /*private void OnApplicationQuit()
    {
        SaveDataItems();
    }

    private void LoadDataItems()
    {
        if (SaveGame.Exists(KEY_DATA))
        {
            InventoryData loadData = SaveGame.Load<InventoryData>(KEY_DATA);
            for(int i = 0; i < inventorySize; i++)
            {
                if(loadData.itemID[i]!= null)
                {
                    Items itemSaved = FindSavedItems(loadData.itemID[i]);
                    if(itemSaved != null)
                    {
                        inventoryItems[i] = itemSaved.CopyItem();
                        inventoryItems[i].amountItem = loadData.itemAmount[i];
                        InventoryUI.Instance.DrawSlot(inventoryItems[i], i);
                    }
                }
                else
                {
                    inventoryItems[i]=null;
                }
            }
        }
    }

    private void SaveDataItems()
    {
        InventoryData datasave = new InventoryData();
        datasave.itemID = new string[inventorySize];
        datasave.itemAmount = new int[inventorySize];
        for(int i = 0; i < inventorySize; i++)
        {
            if(inventoryItems[i] == null)
            {
                datasave.itemID[i] = null;
                datasave.itemAmount[i] = 0;
            }
            else
            {
                datasave.itemID[i] = inventoryItems[i].ID;
                datasave.itemAmount[i] = inventoryItems[i].amountItem;
            }
        }
        SaveGame.Save(KEY_DATA, datasave);
        Debug.Log("Item is saved");
    }*/


    private Items FindSavedItems(string itemId)
    {
        for(int i = 0; i < database.listItems.Length; i++)
        {
            if (database.listItems[i].ID == itemId) return database.listItems[i];
        }
        return null;
    }


    public void AddItem(Items item, int amount)
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
                    if (amount <= 0) return;
                }
            }
        }
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
        AudioManager.Instance.PlaySFX("Click");
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
       /* SaveDataItem();*/
    }


    public void EquipItem()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (inventoryItems[indexCurrentItem] == null) return;
        if (inventoryItems[indexCurrentItem].type != ItemsType.Weapon) return;
        inventoryItems[indexCurrentItem].EquipItem();

    }


    public void RemoveItem()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (inventoryItems[indexCurrentItem] == null) return;
        inventoryItems[indexCurrentItem].RemoveItem();
        inventoryItems[indexCurrentItem] = null;
        InventoryUI.Instance.DrawSlot(null, indexCurrentItem);
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


    private void VerifyToDrawItems()
    {
        for(int i=0;i<inventorySize;i++)
        {
            if (inventoryItems[i] == null)
            {
                InventoryUI.Instance.DrawSlot(null, i);
            }
        }    
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

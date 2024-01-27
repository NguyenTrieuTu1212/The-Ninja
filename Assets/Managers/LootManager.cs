using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [SerializeField] private GameObject lootPanel;
    [SerializeField] private GameObject buttonLootPrefabs;
    [SerializeField] private Transform container;
    [SerializeField] private ButtonLootItem buttonLootItem;
    public void ShowLootChest(EnermyLoot enermyLoot)
    {   
        
        foreach(ItemDrop item in enermyLoot.ItemsDrop)
        {
             GameObject buttonLoot = Instantiate(buttonLootPrefabs, container);
             buttonLootItem.LoadItemDrop(item);
        }
    }


    public void OpenPanelLoot()
    {
        lootPanel.SetActive(true);
    }
    public void CloseandPanelLooting()
    {
        lootPanel.SetActive(false);
    }
}

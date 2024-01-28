using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [SerializeField] private GameObject lootPanel;
    [SerializeField] private ButtonLootItem buttonLootPrefabs;
    [SerializeField] private Transform container;
    public void ShowLootChest(EnermyLoot enermyLoot)
    {
        foreach (ItemDrop item in enermyLoot.ItemsDrop)
        {
            ButtonLootItem buttonLootItem = Instantiate(buttonLootPrefabs, container);
            buttonLootItem.LoadItemDrop(item);
        }
    }

    public void OpenPanelLoot()
    {
        lootPanel.SetActive(true);
    }
    
    public void ClosePanelLooting()
    {
        lootPanel.SetActive(false);
    }
}

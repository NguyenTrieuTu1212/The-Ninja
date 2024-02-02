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
        lootPanel.SetActive(true);
        if (IsHaveItem())
        {
            for(int i = 0; i < container.childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }
        foreach (ItemDrop item in enermyLoot.ItemsDrop)
        {
            ButtonLootItem buttonLootItem = Instantiate(buttonLootPrefabs, container);
            buttonLootItem.LoadItemDrop(item);
        }
    }



    private bool IsHaveItem()
    {
        return container.childCount > 0;
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

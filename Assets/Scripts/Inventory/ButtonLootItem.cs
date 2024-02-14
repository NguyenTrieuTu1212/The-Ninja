using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonLootItem : MonoBehaviour
{
    public ItemDrop itemLoaded { get; private set; }


    [SerializeField] private Image iconItemDrop;
    [SerializeField] private TextMeshProUGUI nameItemDrop;
    [SerializeField] private TextMeshProUGUI amountItemDrop;
    

    public void LoadItemDrop(ItemDrop itemDrop)
    {
        itemLoaded = itemDrop;
        iconItemDrop.sprite = itemDrop.item.icon;
        nameItemDrop.text = itemDrop.item.nameItem;
        amountItemDrop.text = $"X{itemDrop.amountItem}";
    }



    // Collect item 
    public void CollectItemsDrop()
    {
        if (itemLoaded == null) return;
        Inventory.Instance.AddItem(itemLoaded.item, itemLoaded.amountItem);
        itemLoaded.PickedItem = true;
        Destroy(this.gameObject);
    }
}

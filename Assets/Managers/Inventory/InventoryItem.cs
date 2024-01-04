using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemsType
{
    Weapon,
    Potion,
    Scroll,
    Food,
    Treasure,

}

[CreateAssetMenu(menuName ="Iventory Items / Item")]
public class InventoryItem : ScriptableObject
{
    [Header ("Config items")]
    public string ID;
    public string nameItem;
    [TextArea] public string description;


    [Header("Infor item")]
    public Sprite icon;
    public ItemsType type;
    public bool isComsumable;
    public bool isStackable;
    public int maxStack;


    [HideInInspector] public int amountItem;


    public InventoryItem CopyItem()
    {
        InventoryItem instance = Instantiate(this);
        return instance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual void EquiqItem()
    {

    }

    public virtual void RemoveItem()
    {

    }


}

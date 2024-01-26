using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class EnermyLoot : MonoBehaviour
{
    [SerializeField] private float expAmountDrop;
    [SerializeField] private float manaAmoutDrop;
    [SerializeField] private List<ItemDrop> listItemDrop = new List<ItemDrop>();
    public List<ItemDrop> ItemsDrop { get; private set; }
    public float ExpAmountDrop => expAmountDrop;
    public float ManaAmoutDrop => manaAmoutDrop;


    private void Start()
    {
        LoadItemDrop();
    }



    public void LoadItemDrop()
    {
        ItemsDrop = new List<ItemDrop>();
        foreach(ItemDrop item in listItemDrop)
        {
            float percentRandom = Random.Range(0, 100f);
            if(percentRandom < item.chanceDropItem)
            {
                ItemsDrop.Add(item);
            }
        }
    }
}


[Serializable]
public class ItemDrop
{
    [Header("Config Item drop")]
    public string name;
    public Items item;
    public int amountItem;
    
    [Header("Chance drop item")] 
    public float chanceDropItem;
    public bool canPickItem { get; set; }    
}
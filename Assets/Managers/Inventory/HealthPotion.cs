using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Iventory Items/Potion", fileName = "ItemPotion")]
public class HealthPotion : InventoryItem
{
    [Header("Health restore")]
    public float heatlhValue;


    public override bool UseItem()
    {
        if (PlayerManager.Instance.CanRestoreHealthForPlayer())
        {
            PlayerManager.Instance.RestoreHealthForPlayer(heatlhValue);
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Iventory Items/Health Potion", fileName = "ItemHealthPotion")]
public class HealthPotion : Items
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

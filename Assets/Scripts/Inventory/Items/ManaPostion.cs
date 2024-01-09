using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Iventory Items/Mana Potion", fileName = "ItemManaPotion")]
public class ManaPostion : Items
{
    [Header("Mana restore value")]
    public float manaValue;



    public override bool UseItem()
    {
        if (PlayerManager.Instance.CanRestoreManaForPlayer())
        {
            PlayerManager.Instance.RestoreManaForPlayer(manaValue);
            return true;
        }
        return false;
    }
}

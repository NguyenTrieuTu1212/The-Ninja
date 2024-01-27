using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Iventory Items/Weapon",fileName ="ItemWeapon")]
public class ItemsWeapon : Items
{
    public Weapon weapon;
    public override void EquipItem()
    {
        WeaponManager.Instance.EquipItem(weapon);
    }

}

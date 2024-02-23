using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponManager : Singleton<WeaponManager>
{

    [SerializeField] private Image imageWeapon;
    [SerializeField] private TextMeshProUGUI weaponManaTMP;

    protected override void Awake()
    {
        base.Awake();
    }

    public void EquipItem(Weapon weapon)
    {
        imageWeapon.sprite = weapon.iconWeapon;
        imageWeapon.gameObject.SetActive(true);
        weaponManaTMP.text = weapon.RequireMana.ToString();
        weaponManaTMP.gameObject.SetActive(true);
        PlayerManager.Instance.PlayerAttack.EquipWeapon(weapon);
    }

    

}

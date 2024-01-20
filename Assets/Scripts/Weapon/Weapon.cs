using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Melee,
    Magic
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon_Player")]
public class Weapon : ScriptableObject
{

    [Header("Icon Weapon")]
    public Sprite iconWeapon;


    [Header("Type Weapon")]
    public WeaponType weaponType;

    [Header("Damage of Weapon")]
    public float damage;


    [Header("Name Bullet")]
    public string nameBullet;

    [Header("Durability")]
    public float durability;
    public float offset;
    public float maxDurability;

    [Header("Require Mana")]
    public float RequireMana;

    [Header("Require Time")]
    public float requireTime;

}

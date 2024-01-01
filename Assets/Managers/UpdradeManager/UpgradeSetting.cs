using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class UpgradeSetting 
{
    public string nameAttribute;


    [Header("Value upgrade")]
    public float healthUpgrade;
    public float damageUpgrade;
    public float manaUpgrade;
    public float criticalChanceUpgrade;
    public float criticalDamageUpgrade;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] public List<UpgradeSetting> upgradeSettings = new List<UpgradeSetting>();
    private Player player;


    public static event Action OnUpgradeLoad;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void UpgradePlayer(int indexSetting)
    {
        // Damage upgrade
        player.Stats.baseDamage += upgradeSettings[indexSetting].damageUpgrade;


        // Health upgrade
        player.Stats.maxHealth += upgradeSettings[indexSetting].healthUpgrade;
        player.Stats.Health = player.Stats.maxHealth;

        //Mana upgrade
        player.Stats.maxMana += upgradeSettings[indexSetting].manaUpgrade;
        player.Stats.mana = player.Stats.maxMana;

        //Critical Chance Upgrade
        player.Stats.criticalChance += upgradeSettings[indexSetting].criticalChanceUpgrade;

        // Critical Damage
        player.Stats.criticalDamage += upgradeSettings[indexSetting].criticalDamageUpgrade; 

    }

    private void UpgradeStatsCallBack(AttributesType attributes)
    {
        if (player.Stats.atrributePoint == 0) return;
        switch (attributes)
        {
            case AttributesType.strength:
                UpgradePlayer(0);
                player.Stats.strength++;
                break;
            case AttributesType.dexterity:
                UpgradePlayer(1);
                player.Stats.dexterity++;
                break;
            case AttributesType.intelligence:
                UpgradePlayer(2);
                player.Stats.intelligence++;
                break;
        }
        player.Stats.atrributePoint--;
        OnUpgradeLoad?.Invoke();
    }

    private void OnEnable()
    {
        AttributeButton.OnAttributesSelectEvent += UpgradeStatsCallBack;
    }


    private void OnDisable()
    {
        AttributeButton.OnAttributesSelectEvent -= UpgradeStatsCallBack;
    }

}

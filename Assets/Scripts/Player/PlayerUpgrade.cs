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

    /*private void UpgradePlayer(int indexSetting)
    {
        // Damage upgrade
        player.Stats.baseDamage += player.Stats.baseDamage * upgradeSettings[indexSetting].damageUpgrade / 100f;


        // Health upgrade
        player.Stats.maxHealth += upgradeSettings[indexSetting].healthUpgrade;
        player.Stats.maxHealth += player.Stats.maxHealth * upgradeSettings[indexSetting].healthUpgrade / 100f;
        player.Stats.Health = player.Stats.maxHealth;

        //Mana upgrade
        player.Stats.maxMana += player.Stats.maxMana * upgradeSettings[indexSetting].manaUpgrade / 100f;
        player.Stats.mana = player.Stats.maxMana;

        //Critical Chance Upgrade
        player.Stats.criticalChance += player.Stats.criticalChance * upgradeSettings[indexSetting].criticalChanceUpgrade / 100f;

        // Critical Damage
        player.Stats.criticalDamage += player.Stats.criticalDamage * upgradeSettings[indexSetting].criticalDamageUpgrade / 100f;

    }*/

    private void UpgradePlayer(int indexSetting)
    {
        // Damage upgrade
        player.Stats.baseDamage = Mathf.Round(player.Stats.baseDamage * (1 + upgradeSettings[indexSetting].damageUpgrade / 100f) * 10f) / 10f;

        // Health upgrade
        player.Stats.maxHealth = Mathf.Round(player.Stats.maxHealth * (1 + upgradeSettings[indexSetting].healthUpgrade / 100f) * 10f) / 10f;
        player.Stats.Health = player.Stats.maxHealth;

        // Mana upgrade
        player.Stats.maxMana = Mathf.Round(player.Stats.maxMana * (1 + upgradeSettings[indexSetting].manaUpgrade / 100f) * 10f) / 10f;
        player.Stats.mana = player.Stats.maxMana;

        // Critical Chance Upgrade
        player.Stats.criticalChance = Mathf.Round(player.Stats.criticalChance * (1 + upgradeSettings[indexSetting].criticalChanceUpgrade / 100f) * 10f) / 10f;

        // Critical Damage
        player.Stats.criticalDamage = Mathf.Round(player.Stats.criticalDamage * (1 + upgradeSettings[indexSetting].criticalDamageUpgrade / 100f) * 10f) / 10f;
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

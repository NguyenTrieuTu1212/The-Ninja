using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    // current position player
    public Vector3 posPlayer;

    // Stat health player
    public float healthPlayer;
    public float maxHealthPlayer;

    // Stat Mana player
    public float manaPlayer;
    public float maxManaPlayer;

    // Stat exp current player
    public float currentExpPlayer;
    public float expNextLevel;
    public float totalExpPlayer;
    public float totalDamagePlayer;

    // Upgrade
    public int pointAttributePlayer;
    public int levelPlayer;
    public int strengthPlayer;
    public int dexterityPlayer;
    public int intelligencePlayer;

    // Damge
    public float baseDamagePlayer;
    public float criticalChancePlayer;
    public float criticalDamagePlayer;

    // Inventory 
    public InventoryData inventoryData;

    // Init weapon
    public bool isInitWeapon;

    // Quest
    public QuestDataNPC questDataNPC;

    // Music
    public float volumeMusic;
    public float volumeSFX;

    public bool isLoadedQuest;

    public GameData()
    {
        inventoryData = new InventoryData();
        isInitWeapon = false;
        questDataNPC = new QuestDataNPC();
        isLoadedQuest = false;
        posPlayer = Vector3.zero;
        healthPlayer = 10f;
        maxHealthPlayer = 10f;
        manaPlayer = 20f;
        maxManaPlayer = 20f;
        currentExpPlayer = 0f;
        expNextLevel = 100f;
        volumeMusic = 1f;
        volumeSFX = 1f;
        levelPlayer = 1;
        pointAttributePlayer = 1;
        baseDamagePlayer = 2f;
        criticalChancePlayer = 10;
        criticalDamagePlayer = 50;
        strengthPlayer = 0;
        dexterityPlayer = 0;
        intelligencePlayer = 0;
        
    }
}

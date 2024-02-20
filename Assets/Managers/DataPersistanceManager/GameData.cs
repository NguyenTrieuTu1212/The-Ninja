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

    // Inventory 
    public InventoryData inventoryData;

    // Quest
    public QuestDataNPC questDataNPC;

    public float volumeMusic;
    public float volumeSFX;
    public GameData()
    {
        inventoryData = new InventoryData();
        questDataNPC = new QuestDataNPC();
        posPlayer = Vector3.zero;
        healthPlayer = 10f;
        maxHealthPlayer = 10f;
        manaPlayer = 10f;
        maxManaPlayer = 20f;
        currentExpPlayer = 0f;
        expNextLevel = 100f;
        volumeMusic = 1f;
        volumeSFX = 1f;
    }
}

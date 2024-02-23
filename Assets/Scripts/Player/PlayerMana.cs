using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour,IDataPersistance
{
    private Player player;
    public float currentMana { get; private set; }

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        currentMana = player.Stats.mana;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) UsedMana(2f);
    }

    public void LoadGame(GameData gameData)
    {
        player.Stats.mana = gameData.manaPlayer;
        player.Stats.maxMana = gameData.maxManaPlayer;
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.manaPlayer = player.Stats.mana;
        gameData.maxManaPlayer = player.Stats.maxMana;
    }

    public void UsedMana(float amount)
    {
        player.Stats.mana = Mathf.Max(player.Stats.mana-=amount, 0f);
        currentMana = player.Stats.mana;
    }

    public void ResetMana()
    {
        player.Stats.mana = player.Stats.maxMana;
        currentMana = player.Stats.mana;
    }


    public void AddMana(float amount)
    {
        player.Stats.mana += amount;
        currentMana = player.Stats.mana;
    }

    public void RestoreMana(float amountMana)
    {
        player.Stats.mana += amountMana;
        player.Stats.mana = Mathf.Min(player.Stats.mana, player.Stats.maxMana);
    }

    public bool CanRestoreMana()
    {
        return player.Stats.mana >=0f && player.Stats.mana < player.Stats.maxMana;
    }

    
}

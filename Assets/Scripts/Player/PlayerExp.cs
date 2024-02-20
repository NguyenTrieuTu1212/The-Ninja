using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour,IDataPersistance
{
    private Player player;
    
    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        player.Stats.totalExp = 0;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) AddExp(300f);
    }


    public void LoadGame(GameData gameData)
    {
        player.Stats.currentExp = gameData.currentExpPlayer;
        player.Stats.expNextLevel = gameData.expNextLevel;
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.currentExpPlayer = player.Stats.currentExp;
        gameData.expNextLevel = player.Stats.expNextLevel;
    }


    public void AddExp(float amount)
    {
        player.Stats.totalExp += amount;
        player.Stats.currentExp += amount;
        while(player.Stats.currentExp >= player.Stats.expNextLevel)
        {
            player.Stats.currentExp -= player.Stats.expNextLevel;
            NextLevel();
        }
        
    }

    private void NextLevel ()
    {
        player.Stats.atrributePoint++;
        player.Stats.level++;
        float expNextLevel = player.Stats.expNextLevel;
        float expRequiredForNextLevel = Mathf.Round(player.Stats.expNextLevel + (expNextLevel * (player.Stats.expMultiplier / 100f)));
        player.Stats.expNextLevel = expRequiredForNextLevel;
    }

    
}

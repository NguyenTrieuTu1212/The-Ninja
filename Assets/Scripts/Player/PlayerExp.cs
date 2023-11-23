using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private Player player;
    float currentExpPlayer;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) AddExp(300f);
       
    }
    private void AddExp(float amount)
    {
        player.Stats.currentExp += amount;
        while(player.Stats.currentExp >= player.Stats.expNextLevel)
        {
            player.Stats.currentExp -= player.Stats.expNextLevel;
            NextLevel();
        }
        
    }

    private void NextLevel ()
    {
        player.Stats.level++;
        float expNextLevel = player.Stats.expNextLevel;
        float expRequiredForNextLevel = Mathf.Round(player.Stats.expNextLevel + (expNextLevel * (player.Stats.expMultiplier / 100f)));
        player.Stats.expNextLevel = expRequiredForNextLevel;
    }
}

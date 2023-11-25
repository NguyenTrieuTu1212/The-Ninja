using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;
    
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;


    [SerializeField] private TextMeshProUGUI levelTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;

    private void Update()
    {
        LoadStatsPlayerUI();
    }
    private void LoadStatsPlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, 
                                player.Stats.Health / player.Stats.maxHealth, 
                                10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount,
                                player.Stats.mana / player.Stats.maxMana,
                                10f * Time.deltaTime);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount,
                                player.Stats.currentExp / player.Stats.expNextLevel,
                                10f * Time.deltaTime);


        levelTMP.text = $"Level {player.Stats.level}";
        healthTMP.text = $"{player.Stats.Health} / {player.Stats.maxHealth}";
        manaTMP.text = $"{player.Stats.mana} / {player.Stats.maxMana}";
        expTMP.text = $"{player.Stats.currentExp} / {player.Stats.expNextLevel}";
    }

}

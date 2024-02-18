using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAttack playerAttack;
    
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;

    [SerializeField] private TextMeshProUGUI levelTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;

    [SerializeField] private GameObject statsPanel;
    [SerializeField] private TextMeshProUGUI levelStatTMP;
    [SerializeField] private TextMeshProUGUI totalExpTMP;
    [SerializeField] private TextMeshProUGUI damageTMP;
    [SerializeField] private TextMeshProUGUI expStatTMP;
    [SerializeField] private TextMeshProUGUI criticalChanceTMP;
    [SerializeField] private TextMeshProUGUI requireExpTMP;
    [SerializeField] private TextMeshProUGUI criticalDamageTMP;


    [SerializeField] private TextMeshProUGUI strengthTMP;
    [SerializeField] private TextMeshProUGUI dexterityTMP;
    [SerializeField] private TextMeshProUGUI intelligenceTMP;
    [SerializeField] private TextMeshProUGUI attributesPointTMP;

    [SerializeField] private Image imageWeapon;

    [SerializeField] private GameObject panelQuestNPC;
    [SerializeField] private GameObject panelQuestPlayer;


    

    private void Awake()
    {
        statsPanel.SetActive(false);
    }
    private void Update()
    {
        LoadStatsPlayerUI();
        LoadStatsPanelUI();
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

        player.Stats.Health = RoundToDecimalPlaces(player.Stats.Health, 2);
        player.Stats.mana = RoundToDecimalPlaces(player.Stats.mana, 2);

        levelTMP.text = $"Level {player.Stats.level}";
        healthTMP.text = $"{player.Stats.Health} / {player.Stats.maxHealth}";
        manaTMP.text = $"{player.Stats.mana} / {player.Stats.maxMana}";
        expTMP.text = $"{player.Stats.currentExp} / {player.Stats.expNextLevel}";
    }


    private void LoadStatsPanelUI()
    {
        levelStatTMP.text = player.Stats.level.ToString();
        totalExpTMP.text = player.Stats.totalExp.ToString();
        damageTMP.text = player.Stats.baseDamage.ToString();
        expStatTMP.text = player.Stats.currentExp.ToString();
        criticalChanceTMP.text = player.Stats.criticalChance.ToString();
        requireExpTMP.text = player.Stats.expNextLevel.ToString();
        criticalDamageTMP.text = player.Stats.criticalDamage.ToString();

        strengthTMP.text = player.Stats.strength.ToString(); 
        dexterityTMP.text = player.Stats.dexterity.ToString();
        intelligenceTMP.text = player.Stats.intelligence.ToString();

        attributesPointTMP.text = player.Stats.atrributePoint.ToString();

    }

    
    public void OpenAndCloseStats()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
        if (statsPanel.activeSelf)
        {
            LoadStatsPanelUI();
        }
    }
    
    private void LoadUpgradeUICallback()
    {
        LoadStatsPanelUI();
    }


    public void OpenPanelQuest()
    {
        panelQuestNPC.SetActive(true);
        DialogManager.Instance.ClosePanelDialog();
    }


    public void ClosePanelQuest()
    {
        panelQuestNPC.SetActive(false);
        DialogManager.Instance.ClosePanelDialog();
    }

    public void OpenAndClosePanelQuestPlayer(bool value)
    {
        panelQuestPlayer.SetActive(value);
    }

    private void OnEnable()
    {
        PlayerUpgrade.OnUpgradeLoad += LoadUpgradeUICallback;

    }

    private void OnDisable()
    {
        PlayerUpgrade.OnUpgradeLoad -= LoadUpgradeUICallback;
    }


    float RoundToDecimalPlaces(float number, int decimalPlaces)
    {
        float multiplier = Mathf.Pow(10f, decimalPlaces);
        return Mathf.Round(number * multiplier) / multiplier;
    }
}

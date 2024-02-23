using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>,IDataPersistance
{
    [SerializeField] LayerMask whatIsEnermySelectLayerMask;
    private PlayerExp playerExp;
    private PlayerMana playerMana;
    private PlayerHealth playerHealth;
    private Player player;
    public PlayerAttack PlayerAttack { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
        playerExp = GetComponent<PlayerExp>();
        playerMana = GetComponent<PlayerMana>();
        playerHealth = GetComponent<PlayerHealth>();
        PlayerAttack = GetComponent<PlayerAttack>();
    }

    public void AddExpPlayer(float expAmount)
    {
        playerExp.AddExp(expAmount);
    }

    public void AddManaPlayer(float manaAmount)
    {
        playerMana.AddMana(manaAmount);
    }



    public void RestoreManaForPlayer(float amount)
    {
        playerMana.RestoreMana(amount);
    }

    public bool CanRestoreManaForPlayer()
    {
        return playerMana.CanRestoreMana();
    }

    public void RestoreHealthForPlayer(float amount)
    {
        playerHealth.RestoreHealth(amount);
    }

    public bool CanRestoreHealthForPlayer()
    {
        return playerHealth.CanRestoreHealth();
    }



    public Collider2D DetectEnermyToSelect()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 5f, whatIsEnermySelectLayerMask);
        return col;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    public void LoadGame(GameData gameData)
    {
        player.Stats.atrributePoint = gameData.pointAttributePlayer;
        player.Stats.level = gameData.levelPlayer;
        player.Stats.baseDamage = gameData.baseDamagePlayer;
        player.Stats.criticalDamage = gameData.criticalDamagePlayer;
        player.Stats.criticalChance = gameData.criticalChancePlayer;
        player.Stats.totalDamage = gameData.totalDamagePlayer;
        player.Stats.strength = gameData.strengthPlayer;
        player.Stats.dexterity = gameData.dexterityPlayer;
        player.Stats.intelligence = gameData.intelligencePlayer;
        player.Stats.totalExp = gameData.totalExpPlayer;
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.pointAttributePlayer = player.Stats.atrributePoint;
        gameData.levelPlayer = player.Stats.level;
        gameData.baseDamagePlayer = player.Stats.baseDamage;
        gameData.criticalDamagePlayer = player.Stats.criticalDamage;
        gameData.criticalChancePlayer = player.Stats.criticalChance;
        gameData.totalDamagePlayer = player.Stats.totalDamage;
        gameData.strengthPlayer = player.Stats.strength;
        gameData.dexterityPlayer = player.Stats.dexterity;
        gameData.intelligencePlayer = player.Stats.intelligence;
        gameData.totalExpPlayer = player.Stats.totalExp;
    }
}

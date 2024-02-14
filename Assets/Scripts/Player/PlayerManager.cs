using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    private PlayerExp playerExp;
    private PlayerMana playerMana;
    private PlayerHealth playerHealth;
    public PlayerAttack PlayerAttack { get; private set; }

    protected override void Awake()
    {
        base.Awake();
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
}

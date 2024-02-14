using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] LayerMask whatIsEnermySelectLayerMask;
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
}

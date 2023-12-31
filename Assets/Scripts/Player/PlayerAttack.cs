using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnermyBrain enermyTarget;
    private Player player;

    private PlayerAnimations playerAnimations;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    private Transform currentAttackPositon;
    private float currentAttackRotation;
    private List<Transform> listPointAttack = new List<Transform>();

    private Weapon CurrentWeapon;

    [SerializeField] public Weapon initWeapon;

    private bool isAttacking = false;


    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMana = GetComponent<PlayerMana>();
        player = GetComponent<Player>();
        EquidWeapon(initWeapon);
        FindPointsAttacking();
    }

    
    private void Update()
    {
        GetPosistionFire();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }


    private void FindPointsAttacking()
    {
        Transform attackPoints = transform.Find("Attack_Points");
        foreach (Transform attackPoint in attackPoints) listPointAttack.Add(attackPoint);
    }

    public void Attack()
    {
        if (enermyTarget == null || isAttacking) return;
        StartCoroutine(WaitingAttacking());
    }

    IEnumerator WaitingAttacking()
    {
        isAttacking = true; 
        if (currentAttackPositon != null)
        {
            if (player.Stats.mana < initWeapon.RequireMana)
            {
                isAttacking = false;
                yield break;
            }

            BulletShoot bullet = BulletManager.Instance.TakeBullet(initWeapon.nameBullet, currentAttackPositon.position, currentAttackRotation);
            bullet.direction = Vector3.up;
            bullet.damage = GetDamageCritical();
            playerMana.UsedMana(initWeapon.RequireMana);
        }
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttacking(false);
        yield return new WaitForSeconds(initWeapon.requireTime - 0.5f);
        isAttacking = false; 
    }

    private void EquidWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
        player.Stats.totalDamage += player.Stats.baseDamage + CurrentWeapon.damage;
    }


    private float GetDamageCritical()
    {
        float damage = player.Stats.baseDamage;
        damage += initWeapon.damage;
        float randomDamage = Random.Range(0f, 100f);
        if(randomDamage <= player.Stats.criticalChance)
        {
            damage += damage * (player.Stats.criticalDamage/100f);
        }
        return damage;
    }

    private void GetPosistionFire()
    {
        Vector2 currentPositionPlayer = playerMovement.MoveDirection;
        if (currentPositionPlayer != Vector2.zero)
        {
            if (Mathf.Abs(currentPositionPlayer.x) > Mathf.Abs(currentPositionPlayer.y))
            {
                // X�c �?nh h�?ng ngang
                currentAttackPositon = (currentPositionPlayer.x < 0f) ? listPointAttack[0] : listPointAttack[1];
                currentAttackRotation = (currentPositionPlayer.x < 0f) ? 90f : -90f;
            }
            else
            {
                // X�c �?nh h�?ng d?c
                currentAttackPositon = (currentPositionPlayer.y > 0f) ? listPointAttack[2] : listPointAttack[3];
                currentAttackRotation = (currentPositionPlayer.y > 0f) ? 0f : -180f;
            }
        }
    }

    private void OnSelectedToAttackCallBack(EnermyBrain enermySelected)
    {
        enermyTarget = enermySelected;
    }

    private void NoOnSelectedToAttackCallBack()
    {
        enermyTarget = null;
    }

    private void OnEnable()
    {
        SelectorManager.OnSelectedEnermy += OnSelectedToAttackCallBack;
        SelectorManager.NoOnSelectedEnermy += NoOnSelectedToAttackCallBack;
    }


    private void OnDisable()
    {
        SelectorManager.OnSelectedEnermy -= OnSelectedToAttackCallBack;
        SelectorManager.NoOnSelectedEnermy -= NoOnSelectedToAttackCallBack;
    }
}

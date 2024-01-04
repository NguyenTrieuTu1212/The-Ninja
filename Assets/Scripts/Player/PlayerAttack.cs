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

    private Weapon currentWeapon;

    [SerializeField] public Weapon initWeapon;
    [SerializeField][Range(0f, 10f)] private float timeWaitingAttack;
    

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
        if (enermyTarget == null) return;
        StartCoroutine(WatingAttacking());
    }



    IEnumerator WatingAttacking()
    {
        if (currentAttackPositon != null)
        {
            if(playerMana.currentMana < currentWeapon.RequireMana) yield break;
            BulletShoot bullet = BulletManager.Instance.TakeBullet(initWeapon.nameBullet,currentAttackPositon.position, currentAttackRotation);
            bullet.direction = Vector3.up;
            bullet.damage = GetDamageCritical();
            playerMana.UsedMana(currentWeapon.RequireMana);
        }
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(timeWaitingAttack);
        playerAnimations.SetAttacking(false);
    }

    private void EquidWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        player.Stats.totalDamage += player.Stats.baseDamage + currentWeapon.damage;
    }


    private float GetDamageCritical()
    {
        float damage = player.Stats.baseDamage;
        damage += currentWeapon.damage;
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
                // Xác ð?nh hý?ng ngang
                currentAttackPositon = (currentPositionPlayer.x < 0f) ? listPointAttack[0] : listPointAttack[1];
                currentAttackRotation = (currentPositionPlayer.x < 0f) ? 90f : -90f;
            }
            else
            {
                // Xác ð?nh hý?ng d?c
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

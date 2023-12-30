using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnermyBrain enermyTarget;

    private PlayerAnimations playerAnimations;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    private Transform currentAttackPositon;
    private float currentAttackRotation;
    private List<Transform> listPointAttack = new List<Transform>();

    [SerializeField] private Weapon weapon;
    [SerializeField][Range(0f, 10f)] private float timeWaitingAttack;
    

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMana = GetComponent<PlayerMana>();
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

    private void Attack()
    {
        if (enermyTarget == null) return;
        StartCoroutine(WatingAttacking());
    }



    IEnumerator WatingAttacking()
    {
        if (currentAttackPositon != null)
        {
            if(playerMana.currentMana < weapon.RequireMana) yield break;
            BulletShoot bullet = BulletManager.Instance.TakeBullet(currentAttackPositon.position, currentAttackRotation);
            bullet.direction = Vector3.up;
            playerMana.UsedMana(weapon.RequireMana);
        }
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(timeWaitingAttack);
        playerAnimations.SetAttacking(false);
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

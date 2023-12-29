using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnermyBrain enermyTarget;
    private PlayerAnimations playerAnimations;
    private Transform currentAttackPositon;
    private float currentAttackRotation;
    private PlayerMovement playerMovement;
    [SerializeField][Range(0f, 10f)] private float timeWaitingAttack;
    [SerializeField] private List<Transform> listPointAttack;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        listPointAttack  = new List<Transform>();
    }

    private void Start()
    {
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
        Transform transformPointAttack = transform.Find("Attack_Points");
        foreach (Transform t in transformPointAttack) listPointAttack.Add(t);
    }

    private void Attack()
    {
        if (enermyTarget == null) return;
        StartCoroutine(WatingAttacking());
    }



    IEnumerator WatingAttacking()
    {
        BulletShoot bullet = BulletManager.Instance.TakeBullet();
        bullet.Direction = Vector3.up;
        GameObject bulletObj = bullet.gameObject;
        bulletObj.transform.position = currentAttackPositon.position;
        bulletObj.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,currentAttackRotation));
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(timeWaitingAttack);
        playerAnimations.SetAttacking(false);
    }


    private void GetPosistionFire()
    {
        Vector2 currentPositionPlayer = playerMovement.MoveDirection;
        switch (currentPositionPlayer.x)
        {
            case < 0f:
                currentAttackPositon = listPointAttack[0];
                currentAttackRotation = -90f;
                break;

            case > 0f:
                currentAttackPositon = listPointAttack[1];
                currentAttackRotation = -270f;
                break;
        }
        switch (currentPositionPlayer.y)
        {
            case > 0f:
                currentAttackPositon = listPointAttack[2];
                currentAttackRotation = 0f;
                break;

            case < 0f:
                currentAttackPositon = listPointAttack[3];
                currentAttackRotation = -180f;
                break;
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

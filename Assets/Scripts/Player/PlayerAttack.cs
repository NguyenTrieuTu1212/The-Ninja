using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnermyBrain enermyTarget;
    private PlayerAnimations playerAnimations;
    [SerializeField][Range(0f, 10f)] private float timeWaitingAttack; 

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }


    private void Attack()
    {
        if (enermyTarget == null) return;
        StartCoroutine(WatingAttacking());
    }


    IEnumerator WatingAttacking()
    {
        playerAnimations.SetAttacking(true);
        yield return new WaitForSeconds(timeWaitingAttack);
        playerAnimations.SetAttacking(false);
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

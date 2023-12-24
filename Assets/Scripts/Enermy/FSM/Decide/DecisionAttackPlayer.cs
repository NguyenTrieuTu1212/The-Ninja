using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackPlayer : FSMDecision
{

    [SerializeField] private EnermyBrain enermyBrain;
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField][Range(0, 2f)] private float attackRange;


  

    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
    }

    public override bool Decide()
    {
        return IsAttackPlayer();
    }

    private bool IsAttackPlayer()
    {
        Collider2D collisionPlayer = Physics2D.OverlapCircle(enermyBrain.transform.position, attackRange, whatIsTarget);
        if (collisionPlayer != null)
        {
            enermyBrain.target = collisionPlayer.transform;
            return true;
        }
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enermyBrain.transform.position, attackRange);
    }
}

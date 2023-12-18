using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSMDecision
{

    [SerializeField] private EnermyBrain enermy;
    [SerializeField][Range(1f,10f)]private float radius;
    [SerializeField] private LayerMask whatIsTarget;


    private bool isDeteted;

    private void Awake()
    {
        enermy = GetComponent<EnermyBrain>();
    }
    public override bool Decide()
    {
        return IsDetectPlayer();
    }


    private bool IsDetectPlayer()
    {
        return isDeteted = Physics2D.OverlapCircle(enermy.transform.position, radius, whatIsTarget);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enermy.transform.position, radius);

    }
}

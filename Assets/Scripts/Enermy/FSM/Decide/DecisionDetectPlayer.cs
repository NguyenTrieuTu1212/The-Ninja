using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DecisionDetectPlayer : FSMDecision
{

    [SerializeField] private EnermyBrain enermy;
    [SerializeField][Range(1f,10f)]private float radius;
    [SerializeField] private LayerMask whatIsTarget;
    private bool isDeteted;


    /*public static event Action<EnermyBrain> OnDecisionDetected;
    public static event Action NoOnDecisionDetected;*/

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
        FindTargetFollow();
        return isDeteted = Physics2D.OverlapCircle(enermy.transform.position, radius, whatIsTarget);
    }

    private void FindTargetFollow()
    {
        Collider2D target = Physics2D.OverlapCircle(enermy.transform.position, radius, whatIsTarget);
        if (target != null)
        {
            enermy.target = target.transform;
            /*OnDecisionDetected?.Invoke(enermy);*/
        }
        else
        {
            enermy.target = null;
            /*NoOnDecisionDetected?.Invoke();*/
        }
        
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enermy.transform.position, radius);

    }


    
}

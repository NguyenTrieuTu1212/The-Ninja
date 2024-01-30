using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDecideTalk : FSMDecision
{

    [SerializeField][Range(1f,10f)] private float radius;
    [SerializeField] private LayerMask whatIsLayer;


    public override bool Decide()
    {
        if (IsDetected()) DialogueManager.Instance.OpenDialog();
        else DialogueManager.Instance.CloseDialog();
        return IsDetected();
    }

    private bool IsDetected()
    {
        return Physics2D.OverlapCircle(transform.position, radius, whatIsLayer);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

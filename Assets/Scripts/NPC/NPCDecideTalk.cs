using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDecideTalk : FSMDecision
{

    [SerializeField][Range(1f, 10f)] private float radius;
    [SerializeField] private LayerMask whatIsLayer;
    public override bool Decide()
    {
        if (IsDetected()) return true;
        DialogManager.Instance.TalkDialog = null;
        return false;
    }




    private bool IsDetected()
    {
        return Physics2D.OverlapCircle(transform.position, radius, whatIsLayer);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

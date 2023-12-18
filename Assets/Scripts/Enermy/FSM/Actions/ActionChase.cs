using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{


    EnermyBrain enermy;
    [SerializeField] [Range(0f, 10f)] float speedChase;

    private void Awake()
    {
        enermy = GetComponent<EnermyBrain>();
    }


    public override void Action()
    {
        Chasing();
    }

    private void Chasing()
    {
        if (enermy.targetChase == null) return;
        Vector3 dirOfPlayer = enermy.targetChase.position - transform.position;
        if (dirOfPlayer.magnitude > 1.3f) 
            transform.Translate(dirOfPlayer.normalized * speedChase * Time.deltaTime); ;

    }
}

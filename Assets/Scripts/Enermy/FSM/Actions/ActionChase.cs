using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{


    EnermyBrain enermy;
    [SerializeField] [Range(0f, 10f)] float speedChase;
    /*[SerializeField] private GameObject seletedSprite;*/

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
        if (enermy.target == null) return;
        Vector3 dirOfPlayer = enermy.target.position - transform.position;
        if (dirOfPlayer.magnitude > 1.3f) 
            transform.Translate(dirOfPlayer.normalized * speedChase * Time.deltaTime);

    }

    /*private void OnSelectedCallBack(EnermyBrain enermySeleted)
    {
        if (enermy == enermySeleted) seletedSprite.SetActive(true);
    }

    private void NoSelectedCallBack()
    {
        seletedSprite.SetActive(false);
    }


    private void OnEnable()
    {
        DecisionDetectPlayer.OnDecisionDetected += OnSelectedCallBack;
        DecisionDetectPlayer.NoOnDecisionDetected += NoSelectedCallBack;
    }

    private void OnDisable()
    {
        DecisionDetectPlayer.OnDecisionDetected -= OnSelectedCallBack;
        DecisionDetectPlayer.NoOnDecisionDetected -= NoSelectedCallBack;
    }*/
}



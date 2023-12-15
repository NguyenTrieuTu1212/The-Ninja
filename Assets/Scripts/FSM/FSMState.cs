
using System;
using UnityEngine;

[SerializeField]
public class FSMState 
{

    public string ID;
    public FSMAction[] allActions;
    public FSMTransistion[] allTransistions;



    public void UpdateState(EnermyBrain enermyBrain)
    {
        ExcuteActions();
        ExcuteTransistion(enermyBrain);

    }

    public void ExcuteActions()
    {
        for (int i = 0; i < allActions.Length; i++) allActions[i].Action();
    }



    public void ExcuteTransistion(EnermyBrain enermyBrain)
    {
        for(int i = 0; i < allTransistions.Length; i++)
        {
            if (allTransistions == null || allTransistions.Length <= 0) return;
            bool isTrueState = allTransistions[i].decide.Decide();
            if (isTrueState)
            {
                enermyBrain.ChangeState(allTransistions[i].trueState);
            }
            else
            {
                enermyBrain.ChangeState(allTransistions[i].falseState);
            }
        }
    }
}

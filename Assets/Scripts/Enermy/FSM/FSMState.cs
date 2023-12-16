using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
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


    private void ExcuteActions()
    {
        foreach (FSMAction action in allActions) action.Action();
    }


    private void ExcuteTransistion(EnermyBrain enermyBrain)
    {
        foreach(FSMTransistion transistion in allTransistions)
        {
            bool isTrueState = transistion.decide.Decide();
            if (isTrueState)
                enermyBrain.ChangeState(transistion.trueState);
            else 
                enermyBrain.ChangeState(transistion.falseState); 
        }
    }
}

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


    public void UpdateStateEnermy(EnermyBrain enermyBrain)
    {
        ExcuteActions();
        ExcuteTransistionEnermy(enermyBrain);
    }


    public void UpdateStateNPC(NPCBrain npcBrain)
    {
        ExcuteActions();
        ExcuteTransitstionNPC(npcBrain);
    }


    private void ExcuteActions()
    {
        foreach (FSMAction action in allActions) action.Action();
    }


    private void ExcuteTransistionEnermy(EnermyBrain enermyBrain)
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


    private void ExcuteTransitstionNPC(NPCBrain npcBrain)
    {
        foreach(FSMTransistion transtion in allTransistions)
        {
            bool isTrueState = transtion.decide.Decide();
            if(isTrueState)
                npcBrain.ChangeState(transtion.trueState);
            else
                npcBrain.ChangeState(transtion.falseState);
        }
    }
}

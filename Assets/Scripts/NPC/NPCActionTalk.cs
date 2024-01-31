using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActionTalk : FSMAction
{

    [SerializeField] public Dialog dialogToShow;
    public override void Action()
    {
        DialogManager.Instance.TalkDialog = this;
    }



    
}

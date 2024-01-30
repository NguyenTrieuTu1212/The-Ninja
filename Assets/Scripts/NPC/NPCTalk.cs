using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : FSMAction
{
    [SerializeField] private Dialog dialogContent;

    public override void Action()
    {
        DialogueManager.Instance.LoadDialogue(dialogContent);
    }
}

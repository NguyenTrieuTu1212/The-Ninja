using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private DialogueBox dialogueBox;


    public void CloseDialog()
    {
        dialogueBox.CLoseDialog();
    }

    public void LoadDialogue(Dialog dialogBox)
    {
        dialogueBox.LoadDialogueBox(dialogBox);
    }


    public void OpenDialog()
    {
        dialogueBox.OpenDialog();
    }



}

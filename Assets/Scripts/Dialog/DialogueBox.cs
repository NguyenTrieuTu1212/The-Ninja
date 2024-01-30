using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image avatarCharacter;
    [SerializeField] private TextMeshProUGUI nameCharacter;
    [SerializeField] private TextMeshProUGUI dialogueCharacter;


    public void OpenDialog()
    {
        dialoguePanel.SetActive(true);
    }

    public void LoadDialogueBox(Dialog dialogBox)
    {
        avatarCharacter.sprite = dialogBox.imageCharacter;
        nameCharacter.text = dialogBox.nameCharacter;
        dialogueCharacter.text = dialogBox.listDialog[0].ToString();
    }


    public void CLoseDialog()
    {
        dialoguePanel.SetActive(false);
    }
    
}

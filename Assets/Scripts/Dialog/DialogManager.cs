using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] private GameObject panelDialog;
    [SerializeField] private Image avatarCharacter;
    [SerializeField] private TextMeshProUGUI nameCharacter_TMP;
    [SerializeField] private TextMeshProUGUI dialogue_TMP;

    public DialogBox NPCDialogBox;


    private void Update()
    {
        LoadDialog();
    }


    private void OpenPanelDialog()
    {
        panelDialog.SetActive(true);
    }

    private void LoadDialog()
    {
        if (NPCDialogBox == null) return;
        avatarCharacter.sprite = NPCDialogBox.dialogShow.imageCharacter;
        nameCharacter_TMP.text = NPCDialogBox.dialogShow.nameCharacter;
        dialogue_TMP.text = NPCDialogBox.dialogShow.listDialog[0].ToString();
        
    }

    private void ClosePanelDialog()
    {
        panelDialog?.SetActive(false);
    }
    
}

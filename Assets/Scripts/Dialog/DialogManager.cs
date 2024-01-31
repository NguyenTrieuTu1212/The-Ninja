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

    public NPCActionTalk TalkDialog { get; set; }


    private void Update()
    {
        LoadDialog();
    }


    public void OpenPanelDialog()
    {
        panelDialog.SetActive(true);
    }


    private void LoadDialog()
    {
        if (TalkDialog == null) return;
        avatarCharacter.sprite = TalkDialog.dialogToShow.imageCharacter;
        nameCharacter_TMP.text = TalkDialog.dialogToShow.nameCharacter;
        dialogue_TMP.text = TalkDialog.dialogToShow.listDialog[0].ToString();
    }


    public void ClosePanelDialog()
    {
        panelDialog?.SetActive(false);
    }
    
}

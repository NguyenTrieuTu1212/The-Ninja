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

    public DialogBox NPCDialog { get; set; }


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
        if (NPCDialog == null) return;
        avatarCharacter.sprite = NPCDialog.dialogShow.imageCharacter;
        nameCharacter_TMP.text = NPCDialog.dialogShow.nameCharacter;
        dialogue_TMP.text = NPCDialog.dialogShow.listDialog[0].ToString();
    }


    public void ClosePanelDialog()
    {
        panelDialog.SetActive(false);
    }
    


}

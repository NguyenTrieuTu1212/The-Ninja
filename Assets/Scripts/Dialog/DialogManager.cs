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
    private Queue<string> dialoguesQueue = new Queue<string>();
    private int currentDialogIndex=0;
    public Interaction NPCDialog { get; set; }


   
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
        if (currentDialogIndex >= NPCDialog.dialogShow.listDialog.Length)
        {
            currentDialogIndex = 0;
            return;
        }
        avatarCharacter.sprite = NPCDialog.dialogShow.imageCharacter;
        nameCharacter_TMP.text = NPCDialog.dialogShow.nameCharacter;
        dialogue_TMP.text = NPCDialog.dialogShow.listDialog[currentDialogIndex].ToString();
    }

    public void ShowNextDialog()
    {
        currentDialogIndex++;
    }

    public void ClosePanelDialog()
    {
        currentDialogIndex = 0;
        panelDialog.SetActive(false);
    }
    


}

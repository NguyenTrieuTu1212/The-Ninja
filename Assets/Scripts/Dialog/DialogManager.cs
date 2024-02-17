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
    [SerializeField] private Button ButtonNext;
    [SerializeField] private Button ButtonAccept;
    [SerializeField] private Button ButtonReject;
 
    private int currentSentenceIndex=0;
    public Interaction NPCDialog { get; set; }


    private void Update()
    {
        LoadDialog();
    }

    
    private void LoadDialog()
    {
        if (NPCDialog == null || currentSentenceIndex >= NPCDialog.dialogShow.listDialog.Length) return;
        if (currentSentenceIndex == NPCDialog.dialogShow.listDialog.Length - 1)
        {
            ButtonNext.gameObject.SetActive(false);
            SetActiveButtonAcceptAndReject(true);
        }
        else
        {
            SetActiveButtonAcceptAndReject(false);
        }
        avatarCharacter.sprite = NPCDialog.dialogShow.imageCharacter;
        nameCharacter_TMP.text = NPCDialog.dialogShow.nameCharacter;
        dialogue_TMP.text = NPCDialog.dialogShow.listDialog[currentSentenceIndex].ToString();
    }
   
    public void OpenPanelDialog()
    {
        panelDialog.SetActive(true);
    }


    public void ClosePanelDialog()
    {
        // Return to the original sentence
        currentSentenceIndex = 0;
        // Disable next button when ending conversation 
        ButtonNext.gameObject.SetActive(true);
        SetActiveButtonAcceptAndReject(false);
        panelDialog.SetActive(false);

    }

    // Button event Click
    public void ShowNextDialog()
    {
        currentSentenceIndex++;
    }


    private void SetActiveButtonAcceptAndReject(bool value)
    {
        ButtonAccept.gameObject.SetActive(value);
        ButtonReject.gameObject.SetActive(value);
    }
  
}

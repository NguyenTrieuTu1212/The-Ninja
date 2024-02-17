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
    private int currentSentenceIndex=0;
    public Interaction NPCDialog { get; set; }
    public int CurrentSentenceIndex { get { return currentSentenceIndex; } }

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
        if (NPCDialog == null || currentSentenceIndex >= NPCDialog.dialogShow.listDialog.Length) return;
        Debug.Log("Current Sentence is : "+ CurrentSentenceIndex);
        if (currentSentenceIndex == NPCDialog.dialogShow.listDialog.Length - 1) ButtonNext.gameObject.SetActive(false);
        avatarCharacter.sprite = NPCDialog.dialogShow.imageCharacter;
        nameCharacter_TMP.text = NPCDialog.dialogShow.nameCharacter;
        dialogue_TMP.text = NPCDialog.dialogShow.listDialog[currentSentenceIndex].ToString();
    }
    public void ShowNextDialog()
    {
        currentSentenceIndex++;
    }
    public void ClosePanelDialog()
    {
        // Return to the original sentence
        currentSentenceIndex = 0;
        // Disable next button when ending conversation 
        ButtonNext.gameObject.SetActive(true);
        panelDialog.SetActive(false);
    }



    public void LoadQuestButton(Canvas canvasQuestIcon)
    {
        if(canvasQuestIcon.gameObject.transform == null)
        {
            canvasQuestIcon.gameObject.SetActive(false);
            return;
        }
        else
        {
            canvasQuestIcon.gameObject.SetActive(true);
        }
        
    }
    
  
}

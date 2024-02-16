using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameQuest_TMP;
    [SerializeField] private TextMeshProUGUI decriptionQuest_TMP;
    public Quest QuestToComplete { get;  set; }

    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestToComplete = quest;
        nameQuest_TMP.text = quest.questName;
        decriptionQuest_TMP.text = quest.Description;
    }
    public void AccpetQuest()
    {
        if (QuestToComplete == null) return;
        QuestToComplete.questAccepted = true;
        QuestManager.Instance.AcceptQuest(QuestToComplete);
        gameObject.SetActive(false);
    }
}

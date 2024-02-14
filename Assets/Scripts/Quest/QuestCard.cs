using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameQuest_TMP;
    [SerializeField] private TextMeshProUGUI decriptionQuest_TMP;
    public Quest QuestCompleted { get;  set; }

    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestCompleted = quest;
        nameQuest_TMP.text = quest.questName;
        decriptionQuest_TMP.text = quest.Description;
    }


}

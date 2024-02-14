using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Transform questPanel;
    [SerializeField] private QuestCard questcardPrefab;
    [SerializeField] private List<Quest> questList = new List<Quest>();

    


    private void LoadQuestInPanelContainerQuest()
    {
        for(int i = 0; i < questList.Count; i++)
        {
            QuestCard questCard = Instantiate(questcardPrefab, questPanel);
            questCard.ConfigQuestUI(questList[i]);
        }
    }

}

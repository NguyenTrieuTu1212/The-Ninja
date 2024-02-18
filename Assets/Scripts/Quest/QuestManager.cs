using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{

    [Header("Quest Card NPC")]
    [SerializeField] private Transform questPanelNPC;
    [SerializeField] private QuestCardNPC questcardNPCPrefab;

    [Header("Quest Card Player")]
    [SerializeField] private Transform questPanelPlayer;
    [SerializeField] private QuestCardPlayer questCardPlayerPrefab;

    [SerializeField] private List<Quest> questList = new List<Quest>();


    private void Start()
    {
        LoadQuestInPanelContainerQuest();
    }


    public void AcceptQuest(Quest quest)
    {
        QuestCardPlayer questCardPlayer = Instantiate(questCardPlayerPrefab, questPanelPlayer);
        questCardPlayer.ConfigQuestUI(quest);
    }

    private void LoadQuestInPanelContainerQuest()
    {
        for(int i = 0; i < questList.Count; i++)
        {
            QuestCardNPC questCard = Instantiate(questcardNPCPrefab, questPanelNPC);
            questCard.ConfigQuestUI(questList[i]);
        }
    }

    public void UpdateProgress(string IDQuest, int amount)
    {
        Quest questToUpdate = QuestExists(IDQuest);
        if (questToUpdate.questAccepted)
        {
            questToUpdate.AddProgress(amount);
        }
    }
   


    private Quest QuestExists(string IDQuest)
    {
        foreach(Quest quest in questList)
        {
            if (quest.IDQuest == IDQuest) return quest;
        }
        return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : Singleton<QuestManager>/*,IDataPersistance*/
{

    [Header("Quest Card NPC")]
    [SerializeField] private Transform questPanelNPC;
    [SerializeField] private QuestCardNPC questcardNPCPrefab;

    [Header("Quest Card Player")]
    [SerializeField] private Transform questPanelPlayer;
    [SerializeField] private QuestCardPlayer questCardPlayerPrefab;

    [SerializeField] private List<Quest> questList = new List<Quest>();
    [SerializeField] private Database database;
    private QuestDataNPC questDataNPC;

    protected override void Awake()
    {
        base.Awake();
        
    }

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
            questList[i].RessetQuest();
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

    /*public void LoadGame(GameData gameData)
    {
        questDataNPC = gameData.questDataNPC;
        questDataNPC.IDQuest = gameData.questDataNPC.IDQuest;
        questDataNPC.isAccepted = gameData.questDataNPC.isAccepted;
        for(int i = 0; i < questList.Count; i++)
        {
            Quest questCardSaved = FindQuestByID(questDataNPC.IDQuest[i]);
            if (questCardSaved == null || questDataNPC.isAccepted[i]) continue;
            QuestCardNPC questCard = Instantiate(questcardNPCPrefab, questPanelNPC);
            questCard.ConfigQuestUI(questCardSaved);
        }
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.questDataNPC.IDQuest = new string[questList.Count];
        gameData.questDataNPC.isAccepted = new bool[questList.Count];
        for (int i = 0; i < questList.Count; i++)
        {
            gameData.questDataNPC.IDQuest[i] = questList[i].IDQuest;
            gameData.questDataNPC.isAccepted[i] = questList[i].questAccepted;
        }
        gameData.questDataNPC = questDataNPC;

    }*/

    public Quest FindQuestByID(string IDQuest)
    {
        for(int i = 0; i < database.listQuests.Length; i++)
        {
            if(database.listQuests[i].IDQuest == IDQuest) return database.listQuests[i];
        }
        return null;
    }
}

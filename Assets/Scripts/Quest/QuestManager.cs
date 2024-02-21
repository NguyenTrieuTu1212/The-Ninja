using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : Singleton<QuestManager>, IDataPersistance
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
    private bool isLoaded;



    private void Start()
    {
        if (!isLoaded)
        {
            LoadQuestInPanelContainerQuest();
            isLoaded = true;
        }
        else return;
        
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

    public void LoadGame(GameData gameData)
    {
        isLoaded = gameData.isLoadedQuest;
        // if data quest loaded not null -> Get data and load it in panel Quests NPC
        if (gameData.questDataNPC != null)
        {
            questDataNPC = gameData.questDataNPC;

            if (questDataNPC.IDQuest != null && questDataNPC.isAccepted != null)
            {
                for (int i = 0; i < questList.Count; i++)
                {
                    if (questDataNPC.IDQuest.Length > i && !questDataNPC.isAccepted[i])
                    {
                        Quest questCardSaved = FindQuestByID(questDataNPC.IDQuest[i]);
                        if (questCardSaved == null) continue;
                        QuestCardNPC questCard = Instantiate(questcardNPCPrefab, questPanelNPC);
                        questCard.ConfigQuestUI(questCardSaved);
                    }
                    if (questDataNPC.isAccepted[i])
                    {
                        Quest questCardSaved = FindQuestByID(questDataNPC.IDQuest[i]);
                        AcceptQuest(questCardSaved);
                    }
                }
            }
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

        gameData.isLoadedQuest = isLoaded;
        gameData.questDataNPC = questDataNPC;
    }

    public Quest FindQuestByID(string IDQuest)
    {
        for(int i = 0; i < database.listQuests.Length; i++)
        {
            if(database.listQuests[i].IDQuest == IDQuest) return database.listQuests[i];
        }
        return null;
    }
}

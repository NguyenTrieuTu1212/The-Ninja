using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName ="Quest",menuName ="Quest SO")]
public class Quest : ScriptableObject
{
    [Header("Config")]
    public string questName;
    public string IDQuest;
    public int questGoal;
    [TextArea] public string Description;


    [Header("Reward")]
    public int goldReward;
    public int expReward;
    public ItemReward item;

    public int currentQuestStatus;
    public bool questCompleted;
    public bool questAccepted;

    public void AddProgress(int amount)
    {
        currentQuestStatus += amount;
        if(currentQuestStatus >= questGoal)
        {
            currentQuestStatus = questGoal;
            if (questCompleted) return;
            questCompleted = true;
        }
    }


    public void RessetQuest()
    {
        questCompleted = false;
        currentQuestStatus = 0;
    }
    
}



[Serializable]
public class ItemReward
{
    public Items itemReward;
    public int itemAmount;
    public string nameItemReward;
}
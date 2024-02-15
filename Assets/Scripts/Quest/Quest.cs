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
    [TextArea] public string Description;


    [Header("Reward")]
    public int goldReward;
    public int expReward;
    public ItemReward itemReward;


    [HideInInspector] public int currentQuestStatus;
    [HideInInspector] public bool questCompleted;
    [HideInInspector] public bool questAccepted;
}



[Serializable]
public class ItemReward
{
    public Items itemReward;
    public int itemAmount;
    public string nameItemReward;
}
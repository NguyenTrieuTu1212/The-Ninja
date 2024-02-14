using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestCardNPC : QuestCard
{
    [SerializeField] private TextMeshProUGUI Reward_TMP;

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        Reward_TMP.text = $"- {quest.expReward} Exp\n" +
                          $"- {quest.goldReward} Gold\n" +
                          $"- {quest.itemReward.itemAmount}{quest.itemReward.itemReward.name}\n";
    }
}

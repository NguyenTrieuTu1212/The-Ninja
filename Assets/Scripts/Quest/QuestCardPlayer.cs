using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestCardPlayer : QuestCard
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI status_TMP;
    [SerializeField] private TextMeshProUGUI goldReward_TMP;
    [SerializeField] private TextMeshProUGUI expReward_TMP;

    [Header("Item Reward")]
    [SerializeField] private Image itemRewardIcon;
    [SerializeField] private TextMeshProUGUI amountItems;


    [Header("Item Claim")]
    [SerializeField] private Button claimButton;

    private void Awake()
    {
        claimButton.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (QuestToComplete.questCompleted)
        {
            claimButton.gameObject.SetActive(true);
            status_TMP.text = $"Status:\n {QuestToComplete.currentQuestStatus} / {QuestToComplete.questGoal}";
            return;
        }
        status_TMP.text = $"Status:\n {QuestToComplete.currentQuestStatus} / {QuestToComplete.questGoal}";
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        status_TMP.text = $"Status:\n {quest.currentQuestStatus} / {quest.questGoal}";
        goldReward_TMP.text = quest.goldReward.ToString();
        expReward_TMP.text = quest.expReward.ToString();
        itemRewardIcon.sprite = quest.item.itemReward.icon;
        amountItems.text = quest.item.itemAmount.ToString();
    }


    public void ClaimReward()
    {
        AudioManager.Instance.PlaySFX("Claim");
        PlayerManager.Instance.AddExpPlayer(QuestToComplete.expReward);
        Inventory.Instance.AddItem(QuestToComplete.item.itemReward, QuestToComplete.item.itemAmount);
        QuestToComplete.RessetQuest();
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private float health;
    [SerializeField] private Slider healthSlider;
    public float CurrentHealth { get; private set; }
    private EnermyBrain enermyBrain;
    private EnermySelect enermySelect;
    private EnermyLoot enermyLoot;
    private Animator animator;

    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
        enermySelect = GetComponent<EnermySelect>();
        enermyLoot = GetComponent<EnermyLoot>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CurrentHealth = health;
        healthSlider.value = CurrentHealth / health;
    }

    public void TakeDamage(float amount)
    {
        AudioManager.Instance.PlaySFX("Hit");
        CurrentHealth -= amount;
        healthSlider.value = CurrentHealth / health;
        if (CurrentHealth <= 0)
        {
            DisableEnermy();
            QuestManager.Instance.UpdateProgress("Kill1Enenrmy",1);
        }
        else
        {
            DamageText damageText = DamageManager.Instance.TakeDamageText(amount);
            damageText.transform.SetParent(transform);
            damageText.transform.position = transform.position + Vector3.right * 0.5f;
           
        }
    }


    private void DisableEnermy()
    {
        healthSlider.gameObject.SetActive(false);
        animator.SetTrigger("Dead");
        enermyBrain.enabled = false;
        enermySelect.NoEnermySelectedCallBack();
        PlayerManager.Instance.AddExpPlayer(enermyLoot.ExpAmountDrop);
        PlayerManager.Instance.AddManaPlayer(enermyLoot.ManaAmoutDrop);
        /*LootManager.Instance.ShowLootChest(enermyLoot);*/
    }


    public void PlaySFXEnermyDied()
    {
        AudioManager.Instance.PlaySFX("Kill");
    }
}

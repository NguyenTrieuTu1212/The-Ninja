using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHealth : MonoBehaviour,IDamageable
{

    [SerializeField] private float health;
    public float CurrentHealth { get; private set; }
    private EnermyBrain enermyBrain;
    private EnermySelect enermySelect;
    private Animator animator;


    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
        enermySelect = GetComponent<EnermySelect>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            enermyBrain.enabled = false;
            enermySelect.NoEnermySelectedCallBack();
        }
        else
        {
            DamageText damageText = DamageManager.Intance.TakeDamageText(amount);
            damageText.transform.SetParent(transform);
            damageText.transform.position = transform.position + Vector3.right * 0.5f;
        }
    }
}

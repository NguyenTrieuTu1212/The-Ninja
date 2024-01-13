using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimtionBarStat : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Items item;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    private void EffectUseItemCallBack()
    {
        if (!item.UseItem()) return;
        StartCoroutine(WaitingPlayEffect());
    }

    private IEnumerator WaitingPlayEffect()
    {
        animator.SetBool("isWorking", true);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("isWorking", false);
    }


    private void OnEnable()
    {
        Inventory.OnUseItem += EffectUseItemCallBack;
    }


    private void OnDisable()
    {
        Inventory.OnUseItem -= EffectUseItemCallBack;
    }
}

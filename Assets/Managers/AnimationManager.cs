using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Singleton<AnimationManager>
{
    [SerializeField] private List<Animator> animators = new List<Animator>();


    protected override void Awake()
    {
        base.Awake();
    }

    public void PlayAnimation(string ID)
    {
        // Play animation for bar health when use item Health Positon => animtors [0]
        if (ID == "HealthPosion")
        {
            StartCoroutine(WaitingPlayEffect(animators[0]));
            Debug.Log("Play effect add health");
        }
        // Play animation for bar mana when use item Health Mana => animtors [1]
        if (ID == "ManaPosion")
        {
            StartCoroutine(WaitingPlayEffect(animators[1]));
            Debug.Log("Play effect add mana");
        }
    }

    private IEnumerator WaitingPlayEffect(Animator animator)
    {
        animator.SetBool("isWorking", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isWorking", false);
    }
}

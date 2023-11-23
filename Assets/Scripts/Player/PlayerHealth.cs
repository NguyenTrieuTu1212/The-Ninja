using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimations animations;
    [SerializeField][Range(0f, 10f)] float timeToRevival;


    private bool isRevival;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        animations = gameObject.GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(1f);
        if (player.Stats.Health <= 0f && !isRevival) StartCoroutine(WaitingPlayerRivial());

    }

    public void TakeDamage(float amount)
    {
        player.Stats.Health -= amount;
        if(player.Stats.Health <= 0)
        {
            PlayerDead();
            isRevival = false;
        }
    }


    private void PlayerDead()
    {
        animations.SetDeadAnimation();
    }

    IEnumerator WaitingPlayerRivial()
    {
        isRevival = false;
        Debug.Log(isRevival);
        yield return new WaitForSeconds(timeToRevival);
        isRevival = true;
        player.Stats.ResetStats();
        animations.SetRivialAnimation(true);
    }
}

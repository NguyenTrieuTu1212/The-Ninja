using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimations animations;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        animations = gameObject.GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(1f);
    }

    public void TakeDamage(float amount)
    {
        player.Stats.Health -= amount;
        if(player.Stats.Health <= 0) PlayerDead();
    }


    private void PlayerDead()
    {
        animations.SetDeadAnimation();
    }
}

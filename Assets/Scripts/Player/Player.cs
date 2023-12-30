using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerAnimations animations;
    [SerializeField] private PlayerMana playerMana;

    public PlayerStats Stats => stats;

    private void Awake()
    {
        Stats.ResetStats();
        animations = gameObject.GetComponent<PlayerAnimations>();
        playerMana = GetComponent<PlayerMana>();
    }

    public void ResetPlayer()
    {
        Stats.ResetStats();
        animations.ResetPlayerAnimation();
        playerMana.ResetMana();
    }
}

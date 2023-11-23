using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;

    private void Awake()
    {
        Stats.ResetStats();
    }
}

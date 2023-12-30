using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private Player player;
    public float currentMana { get; private set; }


    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        currentMana = player.Stats.mana;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) UsedMana(2f);
    }

    public void UsedMana(float amount)
    {
        player.Stats.mana = Mathf.Max(player.Stats.mana-=amount, 0f);
        currentMana = player.Stats.mana;
    }

    public void ResetMana()
    {
        player.Stats.mana = player.Stats.maxMana;
        currentMana = player.Stats.mana;
    }

}

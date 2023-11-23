using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private Player player;


    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) UsedMana(2f);
    }

    private void UsedMana(float amount)
    {
        player.Stats.mana = Mathf.Max(player.Stats.mana-=amount, 0f);
    }

}

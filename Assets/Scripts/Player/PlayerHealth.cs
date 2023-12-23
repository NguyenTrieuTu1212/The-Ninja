using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable,IDataPersistance
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimations animations;
    [SerializeField][Range(0f, 10f)] float timeToRevival;


    

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        animations = gameObject.GetComponent<PlayerAnimations>();
    }


    public void LoadGame(GameData gameData)
    {
        player.Stats.Health = gameData.healthPlayer;
    }

    public void SaveGame(ref GameData gameData)
    {
        gameData.healthPlayer = player.Stats.Health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(1f);
        if (player.Stats.Health <= 0f && Input.GetKeyDown(KeyCode.R))
            player.ResetPlayer();
        if (player.Stats.Health <= 0f) PlayerDead();
    }

    public void TakeDamage(float amount)
    {
        if (player.Stats.Health <= 0) return;
        DamageManager.Intance.SetTextDamage(amount, transform);
        player.Stats.Health  = Mathf.Max(player.Stats.Health -= amount, 0f);
        /*if(player.Stats.Health <= 0)
        {
            PlayerDead();
            //isRevival = false;
        }*/
    }


    private void PlayerDead()
    {
        animations.SetDeadAnimation();
    }

    

    /*IEnumerator WaitingPlayerRivial()
    {
        isRevival = false;
        yield return new WaitForSeconds(timeToRevival);
        player.ResetPlayer();
        isRevival = true;
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    private Player player;
    private PlayerAnimations animations;
    [SerializeField][Range(0f, 10f)] float timeToRevival;
    private bool isRevival = false;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        animations = gameObject.GetComponent<PlayerAnimations>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(1f);
        if(player.Stats.Health <= 0f && !isRevival) StartCoroutine(WaitingPlayerRivial());
        /*if (player.Stats.Health <= 0f && Input.GetKeyDown(KeyCode.R))
            player.ResetPlayer();*/
        /*if (player.Stats.Health <= 0f) StartCoroutine(WaitingPlayerRivial());*/
    }

    public void TakeDamage(float amount)
    {
        if (player.Stats.Health <= 0) return;
        AudioManager.Instance.PlaySFX("HitPlayer");
        DamageText damageText = DamageManager.Instance.TakeDamageText(amount);
        damageText.transform.SetParent(transform);
        damageText.transform.position = transform.position + Vector3.right * 0.5f;
        player.Stats.Health  = Mathf.Max(player.Stats.Health -= amount, 0f);
    }


   

    public void RestoreHealth(float amount)
    {
        player.Stats.Health += amount;
        if(player.Stats.Health > player.Stats.maxHealth) player.Stats.Health = player.Stats.maxHealth;
    }

    public bool CanRestoreHealth()
    {
        return player.Stats.Health >= 0f && player.Stats.Health < player.Stats.maxHealth;
    }

    public void PlayerDead()
    {
        transform.position = new Vector3(0,-0.5f,0);
        animations.SetDeadAnimation();
        isRevival = false;
    }


    IEnumerator WaitingPlayerRivial()
    {
        isRevival = true;
        PlayerDead();
        yield return new WaitForSeconds(timeToRevival);
        player.ResetPlayer();
    }
}

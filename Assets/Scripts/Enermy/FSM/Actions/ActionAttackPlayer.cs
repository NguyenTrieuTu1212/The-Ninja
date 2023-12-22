using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttackPlayer : FSMAction
{
    
    [SerializeField] private float damage;
    [SerializeField] private float timeWatingNextAttack;
    [SerializeField] private float knockbackForce;

    private Vector3 knockback;
    private EnermyBrain enermyBrain;
    private float timer;


    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
    }

    public override void Action()
    {
        Knockback();
        AttackPlayer();
    }



    private void AttackPlayer()
    {
        if (enermyBrain.target == null) return;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            IDamageable player = enermyBrain.target.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeWatingNextAttack;
        }
    }



    private void Knockback()
    {
        if (enermyBrain.target == null) return;
        Vector2 direction = enermyBrain.target.transform.position - transform.position;
        Rigidbody2D rbPlayer = enermyBrain.target.GetComponent<Rigidbody2D>();
        if (direction.magnitude > 1.2f)
        {
            rbPlayer.AddForce(direction.normalized * knockbackForce,ForceMode2D.Impulse);
        }
        else
        {
            rbPlayer.AddForce(direction.normalized * knockbackForce, ForceMode2D.Force);
        }
    }
}




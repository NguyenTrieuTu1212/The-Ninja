using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttackPlayer : FSMAction
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float damage;
    [SerializeField] private float timeWatingNextAttack;
    [SerializeField] float force;


    private Vector3 knockback;
    private EnermyBrain enermyBrain;
    private float timer;


    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
    }

    public override void Action()
    {
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


}




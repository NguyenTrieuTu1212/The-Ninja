using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShooting : FSMAction
{
    
    [SerializeField] private float damage;


    [SerializeField] private GameObject target;

    private bool isShooting = false;
    private float angle = 0f;
    private float delayBtwAttack = 2f;
    private float delayBetweenShots = 0.2f;
    private EnermyHealth enermyHealth;


    private void Awake()
    {
        enermyHealth = GetComponent<EnermyHealth>();
    }
    public override void Action()
    {
        if (isShooting || enermyHealth.CurrentHealth <= 0f) return;
        if (target == null) StartCoroutine(WaitingShoot());
        else StartCoroutine(WaitingShootTarget());
    }


    private IEnumerator WaitingShoot()
    {
        isShooting = true;

        for (int i = 0; i <= 10; i++)
        {
            Shooting();
            yield return new WaitForSeconds(delayBetweenShots);
        }
        angle = 0f;
        yield return new WaitForSeconds(delayBtwAttack);
        isShooting = false;
    }

    private IEnumerator WaitingShootTarget()
    {
        isShooting = true;
        ShootTarget();
        yield return new WaitForSeconds(delayBtwAttack);
        isShooting = false;
    }




    private void Shooting()
    {
        angle -= 45f;
        BulletShoot bullet = BulletManager.Instance.TakeBullet("Rock", transform.position, angle);
        bullet.direction = Vector2.right;
        bullet.damage = damage;
    }


    private void ShootTarget()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        BulletShoot bullet = BulletManager.Instance.TakeBullet("CanonBall", transform.position, 0f);
        bullet.direction = targetDirection;
        bullet.damage = damage;
    }
}

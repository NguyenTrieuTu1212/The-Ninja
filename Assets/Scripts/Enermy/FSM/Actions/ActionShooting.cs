using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShooting : FSMAction
{
    
    [SerializeField] private float damage;
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
        StartCoroutine(ShootEverySecond());
    }

    private IEnumerator ShootEverySecond()
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


    private void Shooting()
    {
        angle -= 45f;
        BulletShoot bullet = BulletManager.Instance.TakeBullet("Rock", transform.position, angle);
        bullet.direction = Vector2.right;
        bullet.damage = damage;
    }
}

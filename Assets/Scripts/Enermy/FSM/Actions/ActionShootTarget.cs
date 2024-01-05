using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShootTarget : FSMAction
{


    [SerializeField] private GameObject target;
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwShoot;
    bool isShoot = false;
    public override void Action()
    {
        if (isShoot) return;
        StartCoroutine(WatingNextTimeShoot());
    }


    private IEnumerator WatingNextTimeShoot()
    {
        isShoot = true;
        Shoot();
        yield return new WaitForSeconds(timeBtwShoot);
        isShoot = false;
    }

    private void Shoot()
    {
        BulletShoot bullet = BulletManager.Instance.TakeBullet("CanonBall", transform.position, 0f);
        Vector2 targetDirection = (target.transform.position - transform.position).normalized;
        bullet.direction = targetDirection;
        bullet.damage = damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShootTarget : FSMAction
{

    private EnermyHealth enermyHealth;

    [SerializeField] private GameObject target;
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwShoot;
    
    bool isShoot = false;
    Vector3 targetDirection;

    private void Awake()
    {
        enermyHealth = GetComponent<EnermyHealth>();
        
    }

    public override void Action()
    {
        if (isShoot || enermyHealth.CurrentHealth <= 0f) return;
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
        targetDirection = target.transform.position - transform.position;
        BulletShoot bullet = BulletManager.Instance.TakeBullet("CanonBall", transform.position, 0f);
        bullet.direction = targetDirection.normalized;
        bullet.damage = damage;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, target.transform.position);
    }
}

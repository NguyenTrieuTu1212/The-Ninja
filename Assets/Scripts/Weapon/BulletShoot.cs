using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField][Range(0f, 10f)] private float speedBullet;
    public Vector3 direction { get; set; }
    public float damage { get; set; }

    

    private void Update()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col != null)
        {
            col.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            BulletManager.Instance.ReturnBullet(playerAttack.initWeapon.nameBullet,gameObject.GetComponent<BulletShoot>());
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private Animator animator;
    [SerializeField][Range(0f, 10f)] private float speedBullet;
    public Vector3 direction { get; set; }
    public float damage { get; set; }

   

    private void Update()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }


    // Animation event
    public virtual void ReturnBulletInQueue()
    {
        BulletManager.Instance.ReturnBullet(playerAttack.CurrentWeapon.nameBullet, gameObject.GetComponent<BulletShoot>());
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isDestroy", true);
        collision.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isDestroy", false);
    }


    
}

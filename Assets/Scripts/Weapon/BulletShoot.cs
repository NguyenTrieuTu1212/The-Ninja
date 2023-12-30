using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float speedBullet;
    public Vector3 direction { get; set; }
    private void Update()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col != null ) BulletManager.Instance.ReturnBullet(gameObject.GetComponent<BulletShoot>());
    }
}

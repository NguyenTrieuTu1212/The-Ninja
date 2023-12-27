using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float speedBullet;
    [SerializeField] public Vector3 direction;


    private void Update()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }
}

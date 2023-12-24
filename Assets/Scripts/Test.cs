using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform player; // Tham chi?u ð?n ngý?i chõi
    public float attackRange = 5f; // Kho?ng cách t?n công
    public float force = 500f; // L?c tãng t?c c?a k? thù

    void Update()
    {
        // Tính kho?ng cách t? k? thù ð?n ngý?i chõi
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // N?u ngý?i chõi n?m trong vùng t?n công
        if (distanceToPlayer < attackRange)
        {
            // Tính hý?ng t? k? thù ð?n ngý?i chõi
            Vector2 direction = (player.position - transform.position).normalized;

            // Tãng t?c k? thù v? phía ngý?i chõi
            /*GetComponent<Rigidbody2D>().AddForce(direction * force);*/
            player.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}

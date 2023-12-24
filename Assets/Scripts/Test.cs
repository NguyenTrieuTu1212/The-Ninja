using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform player; // Tham chi?u �?n ng�?i ch�i
    public float attackRange = 5f; // Kho?ng c�ch t?n c�ng
    public float force = 500f; // L?c t�ng t?c c?a k? th�

    void Update()
    {
        // T�nh kho?ng c�ch t? k? th� �?n ng�?i ch�i
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // N?u ng�?i ch�i n?m trong v�ng t?n c�ng
        if (distanceToPlayer < attackRange)
        {
            // T�nh h�?ng t? k? th� �?n ng�?i ch�i
            Vector2 direction = (player.position - transform.position).normalized;

            // T�ng t?c k? th� v? ph�a ng�?i ch�i
            /*GetComponent<Rigidbody2D>().AddForce(direction * force);*/
            player.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}

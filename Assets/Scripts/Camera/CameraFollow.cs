using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] [Range(0f, 2f)] private float smooth;
    private Vector3 offset;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(0f, 0f, -10f);
        transform.position = target.position + offset;
    }
    private void Update()
    {
        FollowTarget();
    }


    private void FollowTarget()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}

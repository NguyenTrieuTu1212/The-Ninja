using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWander : FSMAction
{

    [SerializeField] private Vector2 moveRange;
    [SerializeField][Range(1f, 10f)] float moveSpeed;   
    [SerializeField][Range(1f,10f)] private float timeWander;

    private float timer = 0f;
    private Vector3 movePosition;

    private void Start()
    {
        timer = timeWander;
        GetNewPosDestination();
    }
    public override void Action()
    {
        
        timer -= Time.deltaTime;
        Movement();
        if(timer <= 0f)
        {
            timer = timeWander;
            GetNewPosDestination();
        }
       
    }

    private void Movement()
    {
        Vector3 moveDirection = (movePosition - transform.position).normalized;
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, movePosition) >= 0.05f)
        {
            transform.Translate(movement);
        }
    }

    

    private void GetNewPosDestination()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x) * 2.5f;
        float randomY = Random.Range(-moveRange.y, moveRange.y) * 2.5f;
        movePosition = transform.position + new Vector3(randomX, randomY);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, moveRange *2f);
        Gizmos.DrawLine(transform.position, movePosition);
    }

}

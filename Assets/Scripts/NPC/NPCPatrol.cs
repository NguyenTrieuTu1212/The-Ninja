using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : FSMAction
{

    [SerializeField] private string IDWaypoint;
    [SerializeField] private float moveSpeed;

    private Transform wayPoint;
    private Vector3 targetPos;
    private List<Transform> listWaypoint = new List<Transform>();

    private int endPoint;
    private int indexPoint;
    private int duration;

    private void Start()
    {
        SetupWayPoint();
    }


    private void SetupWayPoint()
    {
        wayPoint = WaypointManager.Instance.getWayPoints(IDWaypoint);
        wayPoint.position = transform.position;
        for (int i = 0; i < wayPoint.gameObject.transform.childCount; i++)
            listWaypoint.Add(wayPoint.gameObject.transform.GetChild(i));
        int indexPoint = 0;
        endPoint = listWaypoint.Count -1;
        targetPos = listWaypoint[indexPoint].position;

    }


    public override void Action()
    {
        Patrol();
    }


    private void Patrol()
    {
        Vector2 moveDirection = (targetPos - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, targetPos) <= 0.05f) MoveNextPoint();
    }


    private void MoveNextPoint()
    {
        if (indexPoint == endPoint) duration = -endPoint;
        if (indexPoint == 0) duration = 1;
        indexPoint += duration;
        targetPos = listWaypoint[indexPoint].position;
    }
}

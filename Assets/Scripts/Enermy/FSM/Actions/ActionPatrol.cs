using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSMAction
{

    [SerializeField] private string IDWaypont = "";
    [SerializeField] [Range(1f,10f)] private float speedPatrol;
    [SerializeField] private List<Transform> listPoints;

    private Transform wayPoints;
    private Vector3 targetPos;
    private int indexPoint;
    private int countPoint;
    private int direction;
    

    private void Start()
    {
        wayPoints = WaypointManager.Intance.getWayPoints(IDWaypont);
        for (int i = 0; i < wayPoints.gameObject.transform.childCount; i++)
            listPoints.Add(wayPoints.gameObject.transform.GetChild(i));
        indexPoint = 0;
        targetPos = listPoints[indexPoint].transform.position;
        countPoint = listPoints.Count - 1;
    }

    public override void Action()
    {
        Moving();
    }

    private void Moving()
    {
        Vector3 moveDirection = (targetPos - transform.position).normalized;
        Vector3 movement = moveDirection * speedPatrol * Time.deltaTime;
        transform.Translate(movement);
        if (Vector3.Distance(transform.position,targetPos) <= 0.05f) MoveNextPoint();
    }


    private void MoveNextPoint()
    {
        if (indexPoint == countPoint) direction = -countPoint;
        if(indexPoint == 0) direction = 1;
        indexPoint += direction;
        targetPos = listPoints[indexPoint].transform.position;
    }

}

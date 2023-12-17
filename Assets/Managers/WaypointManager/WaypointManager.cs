using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{

    private List<Transform> listPoints = new List<Transform>();
    private Transform wayPointsObject;

    private static WaypointManager intance;
    public static WaypointManager Intance => intance;


    private void Awake()
    {
        if(intance != null) Debug.Log("More than intance in your game !!!!");
        WaypointManager.intance = this;
    }


    public List<Transform> getListPoints(string name)
    {
        wayPointsObject = transform.GetComponentInChildren<Transform>().Find(name);
        // Load Tranform in list Points
        for (int i = 0; i < wayPointsObject.gameObject.transform.childCount; i++)
            listPoints.Add(wayPointsObject.gameObject.transform.GetChild(i));
        return listPoints;
    }
}

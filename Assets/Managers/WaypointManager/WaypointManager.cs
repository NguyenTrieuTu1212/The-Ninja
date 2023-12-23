using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{

    [SerializeField] private List<Transform> listWayPoints;


    private static WaypointManager intance;
    public static WaypointManager Intance => intance;


    private void Awake()
    {
        if(intance != null)
        {
            Debug.Log("More than intance in your game !!!!");
            return;
        }
        listWayPoints = new List<Transform>();
        WaypointManager.intance = this;
        AddWayPoints();
    }


    private void AddWayPoints()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach (Transform objPrefab in objPrefabs)
        {
            listWayPoints.Add(objPrefab);

        }
        HideWayPoint();
    }


    private void HideWayPoint()
    {
        foreach(Transform objPrefab in listWayPoints) objPrefab.gameObject.SetActive(false);   
    }



    public Transform getWayPoints(string name)
    {
        foreach(Transform transform in listWayPoints)
        {
            if(transform.name == name)
            {
                transform.gameObject.SetActive(true);
                return transform;
            };
        } 
        return null;
    }

    

}

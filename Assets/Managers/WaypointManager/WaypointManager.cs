using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : Singleton<WaypointManager>
{
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> listWayPoints;
    private Dictionary<string, Transform> transformDictionary = new Dictionary<string, Transform>();


    protected override void Awake()
    {
        base.Awake();
        listWayPoints = new List<Transform>();
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
        foreach(Transform objPrefab in listWayPoints)
        {
            transformDictionary[objPrefab.name] = objPrefab;
            objPrefab.gameObject.SetActive(false);
        }
    }


    public Transform getWayPoints(string name)
    {
        if(transformDictionary.TryGetValue(name, out Transform obj))
        {
            Transform waypointTranform = Instantiate(obj, holder);
            waypointTranform.gameObject.SetActive(true);
            return waypointTranform;
        }
        return null;
    }

    

}

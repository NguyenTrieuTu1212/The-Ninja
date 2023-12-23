using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{

    [SerializeField] private List<Transform> listWayPoints;
    private static WaypointManager intance;
    public static WaypointManager Intance => intance;

    private Dictionary<string, Transform> transformDictionary = new Dictionary<string, Transform>();


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
            obj.gameObject.SetActive(true);
            return obj;
        }
        return null;
    }

    

}

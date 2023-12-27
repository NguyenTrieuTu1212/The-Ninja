using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager intance;
    public static BulletManager Instance { get => intance; }

    [SerializeField] private int amount;
    [SerializeField] private List<GameObject> listBulletPrefabs;


    private Dictionary<string, Transform> transformDictionary;
    private Queue<GameObject> queue;    
    private List<string> listBulletNames;
    private Transform pool;




    private void Awake()
    {
        if (intance != null) Debug.LogError("More than intance in your game !!!!!");
        intance = this;
        transformDictionary = new Dictionary<string, Transform>();
        listBulletPrefabs = new List<GameObject>();
        listBulletNames = new List<string>();
        queue = new Queue<GameObject>();
        pool = transform.Find("Holder");
        AddPrefabs();
    }



    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        foreach(Transform child in objPrefabs)
        {
            listBulletPrefabs.Add(child.gameObject);
            listBulletNames.Add(child.gameObject.name);
        }
        HidePrefabs();
        AllPrepare();
    }


    private void HidePrefabs()
    {
        foreach(GameObject child in listBulletPrefabs)
        {
            transformDictionary[child.transform.name] = child.transform;
            child.gameObject.SetActive(false);
        }
    }


    private void Prepare(string name)
    {
        for(int i = 0; i < amount; i++)
        {
            if(transformDictionary.TryGetValue(name, out Transform obj))
            {
                GameObject bullet = Instantiate(obj.gameObject, pool);
            }
        }
    }


    private void AllPrepare()
    {
        foreach(string name in listBulletNames) Prepare(name);
    }


    
}

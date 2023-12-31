using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager intance;
    public static BulletManager Instance { get=>intance;}


    private Dictionary<string, BulletShoot> transformDictionary;
    private Queue<BulletShoot> queueActiveBullet;
    private List<string> listBulletNames;
    private Transform pool;


    
    [SerializeField] private int amount;
    [SerializeField] private List<BulletShoot> listBulletPrefabs;
    




    private void Awake()
    {
        if (intance != null) Debug.Log("More than intance in your game !!!!");
        intance = this;
        transformDictionary = new Dictionary<string, BulletShoot>();
        queueActiveBullet = new Queue<BulletShoot>();
        listBulletPrefabs = new List<BulletShoot>();
        listBulletNames = new List<string>();
        pool = transform.Find("Holder");
        AddBulletPrefabs();
        Prepare("Arrow");
    }


   
    private void AddBulletPrefabs()
    {
        Transform objPrefabs= transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach(Transform obj in objPrefabs)
        {
            listBulletPrefabs.Add(obj.GetComponent<BulletShoot>());
            listBulletNames.Add(obj.name);
            transformDictionary[obj.name] = obj.GetComponent<BulletShoot>();
        }
        HidePrefabs();
    }
    


    private void HidePrefabs()
    {
        foreach(BulletShoot bullet in listBulletPrefabs)
        {
            bullet.gameObject.SetActive(false);
        }
    }

    private void Prepare(string name)
    {
        for (int i = 0; i < amount; i++)
        {
            if (transformDictionary.TryGetValue(name, out BulletShoot obj))
            {
                BulletShoot bullet = Instantiate(obj, pool);
                bullet.gameObject.SetActive(false);
                queueActiveBullet.Enqueue(bullet);
            }
        }
    }

    private void AllPrepare()
    {
        foreach (string name in listBulletNames) Prepare(name);
    }

    public BulletShoot TakeBullet(Vector3 spawnPosition, float rotation)
    {
        if(queueActiveBullet.Count <= 0) Prepare("Arrow");
        BulletShoot bullet = queueActiveBullet.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.gameObject.transform.position = spawnPosition;
        bullet.gameObject.transform.rotation = Quaternion.Euler(0f,0f,rotation);
        return bullet;
    }
    
    public void ReturnBullet(BulletShoot bullet)
    {
        queueActiveBullet.Enqueue((bullet));
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(pool);
    }
    
}

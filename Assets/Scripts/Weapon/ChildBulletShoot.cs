using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBulletShoot : MonoBehaviour
{
    [SerializeField] private string nameBulletEnermy;
    public void ReturnBullet()
    {
        transform.parent.GetComponent<BulletShoot>().ReturnBulletInQueue();
    }
     
    public void ReturnBulletEnermy()
    {
        BulletManager.Instance.ReturnBullet(nameBulletEnermy, transform.parent.gameObject.GetComponent<BulletShoot>());
    }
}

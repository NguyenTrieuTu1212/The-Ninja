using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBulletShoot : MonoBehaviour
{
    public void ReturnBullet()
    {
        transform.parent.GetComponent<BulletShoot>().ReturnBulletInQueue();
    }
}

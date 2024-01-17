using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField][Range(0, 10f)] private float speed;
    Vector3 direction;



    private void Update()
    {
        Moving();
    }




    private void Moving()
    {
        direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}

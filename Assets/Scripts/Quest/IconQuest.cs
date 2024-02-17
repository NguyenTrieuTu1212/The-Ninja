using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IconQuest : MonoBehaviour
{

    [SerializeField] private LayerMask whatIsLayerIconQuest;
    private RaycastHit2D hit;
    private Camera cameraMain;
    public static event Action OnClickIconQuest;


    private void Awake()
    {
        cameraMain = Camera.main;
    }


    private void Update()
    {
        SelectIconQuest();
    }

    private void SelectIconQuest()
    {
        if(Input.touchCount > 0)
        {
            hit = Physics2D.Raycast(cameraMain.ScreenToWorldPoint(Input.GetTouch(0).position),
             Vector2.zero, Mathf.Infinity, whatIsLayerIconQuest);
        }

        if (Input.GetMouseButtonDown(0)){
            hit = Physics2D.Raycast(cameraMain.ScreenToWorldPoint(Input.mousePosition),
             Vector2.zero, Mathf.Infinity, whatIsLayerIconQuest);
        }
        if(hit.collider!= null)
        {
            OnClickIconQuest?.Invoke();
        }
    }

   
}

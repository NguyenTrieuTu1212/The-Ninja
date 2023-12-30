using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectorManager : MonoBehaviour
{
    [SerializeField] private LayerMask enermyMask;
    private Camera cameraMain;

    public static event Action<EnermyBrain> OnSelectedEnermy;
    public static event Action NoOnSelectedEnermy;

    private float lastTapTime;
    private float doubleTapTimeThreshold = 0.5f;

    private RaycastHit2D hit;
    private bool isDoubleTap;
    private void Awake()
    {
        cameraMain = Camera.main;
    }

    private void Update()
    {
       if (CheckDoubleClick()) NoOnSelectedEnermy?.Invoke();
       SelectEnermy();
    }


    private void SelectEnermy()
    {
        
        if (Input.touchCount > 0)
        {
            hit = Physics2D.Raycast(cameraMain.ScreenToWorldPoint(Input.GetTouch(0).position),
             Vector2.zero, Mathf.Infinity, enermyMask);
        }

        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(cameraMain.ScreenToWorldPoint(Input.mousePosition),
             Vector2.zero, Mathf.Infinity, enermyMask);
        }
        if (hit.collider != null)
        {
            EnermyBrain enermy = hit.collider.GetComponent<EnermyBrain>();
            if (enermy == null) return;
            EnermyHealth enermyHealth = enermy.GetComponent<EnermyHealth>();
            if (enermyHealth.CurrentHealth <= 0)
            {
                NoOnSelectedEnermy?.Invoke();
                return;
            }
            OnSelectedEnermy?.Invoke(enermy);
        }
        
    }


    private bool CheckDoubleClick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapTimeThreshold)
                {
                    return true;
                }

                lastTapTime = Time.time;
            }
        }
        return false;
      
    }
}

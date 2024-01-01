using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttributeButton : MonoBehaviour
{
    public static event Action<AttributesType> OnClickButtonAttribute;
    [SerializeField] private AttributesType attributesType;
    public void SelectButtonAddPoint()
    {
        OnClickButtonAttribute?.Invoke(attributesType);
        Debug.Log("Selected is : " + attributesType);
    }
}

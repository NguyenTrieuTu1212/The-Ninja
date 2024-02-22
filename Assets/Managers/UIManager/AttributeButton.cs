using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttributeButton : MonoBehaviour
{
    public static event Action<AttributesType> OnAttributesSelectEvent;
    [SerializeField] private AttributesType attributesType;
    public void SelectButtonAddPoint()
    {
        OnAttributesSelectEvent?.Invoke(attributesType);
        AudioManager.Instance.PlaySFX("ClickButton");
    }
}

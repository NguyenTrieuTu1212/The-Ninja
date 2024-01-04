using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyLoot : MonoBehaviour
{
    [SerializeField] private float expAmountDrop;
    [SerializeField] private float manaAmoutDrop;
    public float ExpAmountDrop => expAmountDrop;
    public float ManaAmoutDrop => manaAmoutDrop;
}

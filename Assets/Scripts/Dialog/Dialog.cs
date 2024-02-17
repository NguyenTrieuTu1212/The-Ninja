using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;


public enum InterationType
{
    Talk,
    Quest,
    Shop
}



[CreateAssetMenu(fileName = "Dialog" ,menuName ="Dialog System")]
public class Dialog : ScriptableObject
{
    [Header("Config")]
    public string nameCharacter;
    public Sprite imageCharacter;
    public InterationType type; 

    [Header("Dialog")]
    [TextArea] public string[] listDialog;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public Vector3 posPlayer;
    public float healthPlayer;
    public InventoryData inventoryData;
    public GameData()
    {
        inventoryData = new InventoryData();
        posPlayer = Vector3.zero;
        healthPlayer = 10f;
    }
}

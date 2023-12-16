using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistaceManager : MonoBehaviour
{
    public GameData gameData;
    private DataPersistaceManager intance;
    public DataPersistaceManager Intance => intance;

    private void Awake()
    {
        if (intance != null)
        {
            Debug.Log("More than one intance in Game");
            Destroy(gameObject);
            return;
        }
        intance = this;
    }



    private void NewGame()
    {
        gameData = new GameData();
    }

    private void LoadGame()
    {

    }
    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistaceManager : MonoBehaviour
{

    public static DataPersistaceManager instance { get; private set; }
    private GameData gameData;
    private List<IDataPersistance> listDataPersistances = new List<IDataPersistance>();
    private FileHandlerData fileHandlerData;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one intance in Game !!!");
            Destroy(gameObject);
            return;
        }
        instance = this;
        fileHandlerData = new FileHandlerData("Assets\\Data", "GameData.txt");
    }



    private void Start()
    {
        listDataPersistances = FindAllDataInObject();
        LoadGame();
    }
    private void NewGame()
    {
        gameData = new GameData();
    }

    private void LoadGame()
    {
        gameData = fileHandlerData.ReadData();
        if (this.gameData == null)
        {
            Debug.Log("Can not find data in your game !!!");
            NewGame();
        }
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        Debug.Log("Location of Player is loaded " + gameData.posPlayer);
    }

    private void SaveGame()
    {
        foreach(IDataPersistance persistance in listDataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }
        fileHandlerData.WriteData(gameData);
        Debug.Log("Location of Player is saved " + gameData.posPlayer);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    private List<IDataPersistance> FindAllDataInObject()
    {
        IEnumerable<IDataPersistance> listDataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(listDataPersistances);
    }

}

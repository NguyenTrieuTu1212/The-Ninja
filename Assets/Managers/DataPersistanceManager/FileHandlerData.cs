using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileHandlerData
{
    public string dataDirPath = "";
    public string dataFileName = "";


    public FileHandlerData(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        CreateFileIfNotExists();
    }



    private void CreateFileIfNotExists()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath).Close();
            Debug.Log("File created at: " + fullPath);
        }
    }

    public GameData ReadData()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            string jsonData = File.ReadAllText(fullPath);
            GameData loadedData = JsonUtility.FromJson<GameData>(jsonData);
            Debug.Log("Data read from: " + fullPath);
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }



    public void WriteData(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            string jsonData = JsonUtility.ToJson(data, true);
            File.WriteAllText(fullPath, jsonData);
            Debug.Log("Data written to: " + fullPath);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
}
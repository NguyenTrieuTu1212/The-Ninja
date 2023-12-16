using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance 
{
    public void LoadGame(GameData gameData);
    public void SaveGame(ref GameData gameData);
    
}

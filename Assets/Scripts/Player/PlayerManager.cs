using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }


    private PlayerExp playerExp;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than intance in your game !!!!");
            return;
        }
        instance = this;
        playerExp = GetComponent<PlayerExp>();
    }

    public void AddExpPlayer(float expAmount)
    {
        playerExp.AddExp(expAmount);
    }

}

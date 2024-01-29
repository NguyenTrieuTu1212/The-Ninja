using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBrain : MonoBehaviour
{

    public FSMState curretState { get; private set; }
    public Transform target { get; set; }
    public string initState = "";
    public FSMState[] states;
   

    private void Start()
    {
        curretState = GetState(initState);
    }


    private void Update()
    {
        curretState?.UpdateStateEnermy(this);
    }

    public void ChangeState(string newStateID)
    {
        FSMState newState = GetState(newStateID);
        if (newState == null) return;
        curretState = newState;
    }


    private FSMState GetState(string newStateID)
    {
        foreach (FSMState state in states) if (state.ID == newStateID) return state;
        return null;
    }
}

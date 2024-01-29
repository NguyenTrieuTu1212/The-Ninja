using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : MonoBehaviour
{
    public FSMState CurrenrState { get; set; }
    public string initSate = "";
    public FSMState[] listState;



    private void Start()
    {
        CurrenrState = GetState(initSate);
    }

    private void Update()
    {
        CurrenrState?.UpdateStateNPC(this);
    }



    public void ChangeState(string stateID)
    {
        FSMState newState = GetState(stateID);
        if (newState == null) return;
        CurrenrState = newState;
    }

    private FSMState GetState(string stateID)
    {
        foreach (FSMState state in listState)
            if(state.ID == stateID) return state;
        return null;
    }



}

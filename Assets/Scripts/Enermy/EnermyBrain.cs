using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBrain : MonoBehaviour
{

    public FSMState[] states;
    public string initState;


    private FSMState currentState;


    private void Start()
    {
        currentState = GetState(initState);
    }


    private void Update()
    {
        currentState.UpdateState(this);
    }


    public void ChangeState(string newIDState)
    {
        FSMState newState = GetState(newIDState);
        if (newState == null) return;
        currentState = newState;
        
    }

    private FSMState GetState(string newIDState)
    {
        for(int i = 0; i < states.Length; i++)
        {
            if(states[i].ID == newIDState)
            {
                return states[i];
            }
        }
        return null;
    }


}

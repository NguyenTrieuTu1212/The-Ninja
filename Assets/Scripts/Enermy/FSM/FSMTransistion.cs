
using System;

[Serializable]
public class FSMTransistion { 
    public FSMDecision decide;
    public string trueState;
    public string falseState;
}

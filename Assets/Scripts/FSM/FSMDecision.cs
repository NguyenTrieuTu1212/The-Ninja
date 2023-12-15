using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision :MonoBehaviour
{

    // Th?c hi?n s? quy?t ð?nh có nên chuy?n hay không
    public abstract bool Decide(); 
}

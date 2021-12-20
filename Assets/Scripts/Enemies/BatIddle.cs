using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatIddle : Bat
{
    private bool awake = false;
    public override void DetectPlayer(Transform player)
    {
        if(!awake)
        {
            bool changed = StateMachine.TryChangeState(_stateContainer._additional[0]);
            awake = true;
        }
    }
}

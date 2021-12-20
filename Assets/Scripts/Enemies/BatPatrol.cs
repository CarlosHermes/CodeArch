using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPatrol : Bat
{
    public override void DetectPlayer(Transform player)
    {
        StateMachine.TryChangeState(Vector3.Distance(Focus.transform.position, transform.position) < _attackDistance ?
        StateContainer._attackState : StateContainer._chaseState);
    }
}

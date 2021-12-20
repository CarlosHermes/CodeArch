using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New BatPatrolState", menuName = "ScriptableObjects/States/BatPatrolState")]
public class BatPatrolState : PatrolState
{
    public override void OnEnterState(Enemy enemy)
    {
        base.OnEnterState(enemy);
    }

    public override void OnUpdateState(Enemy enemy)
    {
        base.OnUpdateState(enemy);
    }

    public override void OnExitState(Enemy enemy)
    {
        base.OnExitState(enemy);
    }
}

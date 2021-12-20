using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New BeePatrolState", menuName = "ScriptableObjects/States/BeePatrolState")]
public class BeePatrolState : PatrolState
{
    public void OnEnterState(Enemy enemy)
    {
        base.OnEnterState(enemy);
    }

    public void OnUpdateState(Enemy enemy)
    {
        base.OnUpdateState(enemy);
    }

    public void OnExitState(Enemy enemy)
    {
        base.OnExitState(enemy);
    }
}

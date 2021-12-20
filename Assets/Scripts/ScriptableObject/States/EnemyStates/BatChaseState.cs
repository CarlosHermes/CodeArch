using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BatChaseState", menuName = "ScriptableObjects/States/BatChaseState")]
public class BatChaseState : ScriptableState
{
    public override void OnEnterState(Enemy enemy)
    {
        enemy.Animancer.Play(enemy.ScriptableClips.RunClip);
        enemy.Agent.isStopped = false;
    }

    public override void OnExitState(Enemy enemy)
    {
    }

    public override void OnUpdateState(Enemy enemy)
    {
        enemy.Agent.destination = enemy.Focus.position;
        if (Vector3.Distance(enemy.Focus.transform.position, enemy.transform.position) < enemy._attackDistance)
            enemy.StateMachine.TryChangeState(enemy.StateContainer._attackState);

    }

}

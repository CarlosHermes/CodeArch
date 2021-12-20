using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeeChaseState", menuName = "ScriptableObjects/States/BeeChaseState")]
public class BeeChaseState : ScriptableState
{
    public override void OnEnterState(Enemy enemy) 
    {
        enemy.Animancer.Play(enemy.ScriptableClips.RunClip);
        enemy.Agent.isStopped = false;
    }
    public override void OnUpdateState(Enemy enemy)
    {
        enemy.Agent.destination = enemy.Focus.position;
        if (Vector3.Distance(enemy.Focus.transform.position, enemy.transform.position) < enemy._attackDistance)
            enemy.StateMachine.TryChangeState(enemy.StateContainer._attackState);
    }

    public override void OnExitState(Enemy enemy)
    {
    }
}

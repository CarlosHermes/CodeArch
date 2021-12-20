using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeeIddleState", menuName = "ScriptableObjects/States/BeeIddleState")]
public class BeeIddleState : ScriptableState
{
    public override void OnEnterState(Enemy enemy)
    {
        var state = enemy.Animancer.Play(enemy.ScriptableClips.IddleClip);
        enemy.Agent.isStopped = true;
    }
    public override void OnUpdateState(Enemy enemy)
    {
    }

    public override void OnExitState(Enemy enemy)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DieState", menuName = "ScriptableObjects/States/DieState")]
public class DieState : ScriptableState
{
    public override void OnEnterState(Enemy enemy) 
    {
        var state = enemy.Animancer.Play(enemy.ScriptableClips.DieClip);
        enemy.Agent.isStopped = true;
    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {
        return; //
    }
}

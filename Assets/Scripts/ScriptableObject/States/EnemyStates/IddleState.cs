using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New IddleState", menuName = "ScriptableObjects/States/IddleState")]
public class IddleState : ScriptableState
{
    public override void OnEnterState(Enemy enemy) 
    {
        enemy.Animancer.Play(enemy.ScriptableClips.IddleClip);
        enemy.Agent.isStopped = true;
    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {
    }
}

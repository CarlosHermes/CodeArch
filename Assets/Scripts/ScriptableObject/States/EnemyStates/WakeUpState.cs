using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WakeUpState", menuName = "ScriptableObjects/States/WakeUpState")]
public class WakeUpState : ScriptableState
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

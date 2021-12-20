using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeeAttackState", menuName = "ScriptableObjects/States/BeeAttackState")]
public  class BeeAttackState : ScriptableState
{
    public override void OnEnterState(Enemy enemy)
    {
        enemy.Animancer.Play(enemy.ScriptableClips.AttackClip);
        enemy.Agent.isStopped = true;
    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {
        enemy.transform.LookAt(enemy.Focus.transform);
    }
}

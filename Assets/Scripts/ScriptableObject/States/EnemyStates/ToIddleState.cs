using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ToIddleState", menuName = "ScriptableObjects/States/ToIddleState")]
public class ToIddleState : ScriptableState //BORRAR
{
    public override void OnEnterState(Enemy enemy) //borrar todo el script
    {
        enemy.Animancer.Play(enemy.ScriptableClips.AttackClip);
        enemy.Agent.isStopped = true;
    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeePointState", menuName = "ScriptableObjects/States/BeePointState")]
public class BeePointState : ScriptableState
{
    public override void OnEnterState(Enemy enemy)
    {
        //enemy.transform.LookAt(enemy.Focus.transform);
        var state = enemy.Animancer.Play(enemy.ScriptableClips.Additional[0]);
        Debug.Log("add0");
        enemy.Agent.isStopped = true;
    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {
        enemy.transform.LookAt(enemy.Focus);
    }
}

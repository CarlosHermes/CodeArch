using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BatIddleState", menuName = "ScriptableObjects/States/BatIddleState")]
public class BatIddleState : ScriptableState
{
    public override void OnEnterState(Enemy enemy) //go back to Iddle
    {

    }

    public override void OnExitState(Enemy enemy)
    {
        
    }

    public override void OnUpdateState(Enemy enemy)
    {

    }
}

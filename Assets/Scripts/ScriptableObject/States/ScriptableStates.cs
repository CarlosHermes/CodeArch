using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ScriptableState : ScriptableObject, IState
{
    public abstract void OnEnterState(Enemy enemy);
    public abstract void OnUpdateState(Enemy enemy);
    public abstract void OnExitState(Enemy enemy);

}

public interface IState
{
    void OnEnterState(Enemy enemy);
    void OnExitState(Enemy enemy);
    void OnUpdateState(Enemy enemy);
}

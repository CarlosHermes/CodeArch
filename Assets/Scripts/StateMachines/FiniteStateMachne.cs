using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FiniteStateMachine<T> where T : ScriptableState, IState
{
    [SerializeField] private List<T> _stateMachines;
    private T _currentState;
    private T _previousState;
    private T _nextState;
    private Enemy _ownStateMachine;
    
    public FiniteStateMachine(Enemy enemy, T state)
    {
        _stateMachines = new List<T>();
        _stateMachines.Add(state);
        _ownStateMachine = enemy;
        _currentState = state;
        _currentState.OnEnterState(_ownStateMachine);
    }

    public T CurrentState
    {
        get => _currentState;
        private set
        {
            _currentState.OnExitState(_ownStateMachine);
            _currentState = value;
            _currentState.OnEnterState(_ownStateMachine);
        }
    }

    public bool TryChangeState(T targetState)
    {
       
        var key = _currentState.GetType();
        if (StatesDictionary.stateTransitions.TryGetValue(key, out var value) && value.Contains(targetState.GetType()))
        {
            _previousState = _currentState;
            CurrentState = targetState;
            if (!_stateMachines.Contains(targetState)) _stateMachines.Add(targetState);
            return true;
        }
        return false;
    }

    public void ForceChangeState(T targetState)
    {
        CurrentState = targetState;
    }
}

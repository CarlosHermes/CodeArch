using System;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] protected T _value;
    [SerializeField] protected bool _trackable;
    [SerializeField] protected SUnityEvent _sUnityEvent;

    public SUnityEvent SUnityEvent { get; private set; }

    public T Value
    {
        get => _value;
        set {
            _value = value;
            if (_trackable && _sUnityEvent)
                _sUnityEvent.Invoke();
        }
    }
}

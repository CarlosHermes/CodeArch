using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New SSharpEvent", menuName = "ScriptableObjects/Events/Scriptable CSharp Event", order = 1)]
public class SSharpEvent : ScriptableEvent
{
    private event Action _onInvokeEvent = delegate {  };
    
    public event Action OnInvokeEvent
    {
        add => _onInvokeEvent += value;
        remove => _onInvokeEvent -= value;
    }

    public void AddSubscriber(Action subscriber) => _onInvokeEvent += subscriber;

    public void RemoveSubscriber(Action subscriber) => _onInvokeEvent -= subscriber;

    public override void Invoke() => _onInvokeEvent.Invoke();
}
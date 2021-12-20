using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New SoUnityEvent", menuName = "ScriptableObjects/Events/Scriptable Unity Event", order = 1)]
public class SUnityEvent : ScriptableEvent
{
    [SerializeField] private List<SUnityEventSub> _subscribers;

    public override void Invoke()
    {
        for(int i = _subscribers.Count -1; i >= 0; i--)
            _subscribers[i].OnInvokeEvent();
    }

    public void AddSubscriber(SUnityEventSub subscriber)
    { _subscribers.Add(subscriber); }

    public void RemoveSubscriber(SUnityEventSub subscriber)
    { _subscribers.Remove(subscriber); }
}

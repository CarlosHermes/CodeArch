using UnityEngine;
using UnityEngine.Events;

public class SUnityEventSub : MonoBehaviour
{
    [SerializeField] private SUnityEvent _eventCause;
    [SerializeField] private UnityEvent _eventEffect;

    private void OnEnable()
    {
        if (_eventCause == null)
            _eventCause = ScriptableObject.CreateInstance<SUnityEvent>();
        _eventCause.AddSubscriber(this);
    }

    private void OnDisable() => _eventCause.RemoveSubscriber(this);

    public void OnInvokeEvent() => _eventEffect.Invoke();
}
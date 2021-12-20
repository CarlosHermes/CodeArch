public interface ISSharpEventSub<T>
{
    SSharpEvent EventCause { get; set; }
    void OnEnable();
    void OnDisable();
    void OnInvokeEvent();
}

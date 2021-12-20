using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class Vector2UnityEvent : UnityEvent<Vector2> { }

[Serializable]
public class ContextInputEvent : UnityEvent<InputAction.CallbackContext> { }

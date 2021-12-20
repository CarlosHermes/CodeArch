using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(CapsuleCollider))]
public class DPlayerController: MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    
    private Controls _controls;
    private Vector2 _moveAxis;
    private Vector2 _lookAxis;
    private MoveBehaviour _moveBehaviour;
    private CuriousBehaviour _curiousBehaviour;
    [SerializeField] private DBow _bow;
    private DDagger _dagger;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _curiousBehaviour = GetComponent<CuriousBehaviour>();
        _dagger = GetComponentInChildren<DDagger>();
        _bow = GetComponentInChildren<DBow>();
        _controls = new Controls();
        
        _controls.Player.Move.performed += (context) => _moveAxis = context.ReadValue<Vector2>();
        _controls.Player.Move.canceled += (context) => _moveAxis = Vector2.zero;
        
        _controls.Player.Look.performed += (context) => _lookAxis = context.ReadValue<Vector2>();
        _controls.Player.Look.canceled += (context) => _lookAxis = Vector2.zero;

        _controls.Player.Attack.performed += (context) =>  _bow.PrepareAttack();
        _controls.Player.Attack.canceled += (context) => _bow.ReleaseAttack();

        _controls.Player.Interact.performed += (context) => _curiousBehaviour.Inspect();
        //_controls.Player.Interact.canceled += (context) => _lookAxis = Vector2.zero;
    }

    private void FixedUpdate()
    {
        //_moveBehaviour.MoveForward(_moveAxis);
        _moveBehaviour.Move(_moveAxis);
    }

    private void Update()
    {
        if (_cam.hasChanged)
            transform.forward = _cam.forward.ProjectOntoPlane(Vector3.up);
    }

    public void OnEnable() => _controls.Player.Enable();
    private void OnDisable() => _controls.Player.Disable();
}

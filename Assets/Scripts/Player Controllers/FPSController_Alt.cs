using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CapsuleCollider))]
public class FPSController_Alt : MonoBehaviour
{
    [SerializeField] private Transform _povCam;
    private PlayerInput _playerInput;
    private Vector2 _moveAxis;
    private float _rotY;
    private Quaternion _targetBodyRotation;
    public MoveBehaviour _moveBehaviour;
    [SerializeField] [Range(0.1f, 1f)] private float _smoothCam;

    public void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        //_playerInput.actions["Fire"].performed += OnFire;
        _playerInput.actions["Move"].performed += ctx => _moveAxis = ctx.ReadValue<Vector2>();
        _playerInput.actions["Move"].canceled += ctx => _moveAxis = Vector2.zero;
        //_playerInput.actions["Reload"].performed += ctx => _weapon.Reload();
        //_moveBehaviour = GetComponent<MoveBehaviour>();
        if (_povCam == null)
        {
            //_povCam = Camera.main.transform;
        }
    }

    public void FixedUpdate()
    {
        _moveBehaviour.MoveForward(_moveAxis);
        /*
        if (_povCam.hasChanged)
        {
            _rotY = _povCam.eulerAngles.y - transform.eulerAngles.y;
            _targetBodyRotation = Quaternion.Euler(0f, _rotY, 0f);
        }

        if (_targetBodyRotation != transform.rotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetBodyRotation, _smoothCam);
            */
    }

    #region INPUT_CALLBACKS
    public void OnFire(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(_povCam.position, _povCam.forward, out var aimTo, Mathf.Infinity))
            ; //_weapon.Shoot(aimTo.point);
        //else
        //_weapon.Shoot(_povCam.forward * 50f);
    }
    #endregion
    
    //public void OnEnable() => _playerInput.actions.Enable();
    //private void OnDisable() => _playerInput.actions.Disable();
}
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(CapsuleCollider))]
public class FPSController : MonoBehaviour
{
    private Controls _controls;
    private Vector2 _moveAxis;
    private Vector2 _lookAxis;
    
    [SerializeField] private Transform _cam;

    private MoveBehaviour _moveBehaviour;
    private CuriousBehaviour _curiousBehaviour;
    
    //[SerializeField] [Range(0.1f, 1f)] private float _smoothCam;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    //public InputActionReference ac;

    private WeaponSet _weapons;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _curiousBehaviour = GetComponent<CuriousBehaviour>();
        _weapons = GetComponent<WeaponSet>();
        
        _controls = new Controls();

        _controls.Player.Move.performed += (context) => _moveAxis = context.ReadValue<Vector2>();
        _controls.Player.Move.canceled += (context) => _moveAxis = Vector2.zero;
        
        _controls.Player.Look.performed += (context) => _lookAxis = context.ReadValue<Vector2>();
        _controls.Player.Look.canceled += (context) => _lookAxis = Vector2.zero;

        _controls.Player.Attack.performed += (context) => _weapons.ActiveWeapon.StartAttack();
        _controls.Player.Attack.canceled += (context) => _weapons.ActiveWeapon.StopAttack();

        _controls.Player.Interact.performed += (context) => _curiousBehaviour.Inspect();
        //_controls.Player.Interact.canceled += (context) => _lookAxis = Vector2.zero;
    }

    private void FixedUpdate()
    {
        _moveBehaviour.MoveForward(_moveAxis);
    }

    private void Update()
    {
        if (_cam.hasChanged)
            transform.forward = _cam.forward.ProjectOntoPlane(Vector3.up);
    }


    #region INPUT_CALLBACKS
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            /*
            if (Physics.Raycast(_cam.position, _cam.forward, out var aimTo, Mathf.Infinity))
                _weapon.Shoot(aimTo.point);
            else
                _weapon.Shoot(_cam.forward * 50f);
                */
            ;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            _moveAxis = context.ReadValue<Vector2>();
        else if (context.canceled)
            _moveAxis = Vector2.zero;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        /*
        if (context.performed)
        {
            _lookAxis += _mouseSensitivity * context.ReadValue<Vector2>();
            _lookAxis.y = Mathf.Clamp(_lookAxis.y, -85f, 90f);
            _targetBodyRotation = Quaternion.Euler(0f, _lookAxis.x, 0f);
            _targetCamRotation = Quaternion.Euler(-_lookAxis.y, 0f, 0f);
        }
        Update(){
        if (_cam.localRotation != _targetCamRotation)
            _cam.localRotation = Quaternion.Slerp(_cam.localRotation, _targetCamRotation, _smoothCam);
        if (transform.rotation != _targetBodyRotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetBodyRotation, _smoothCam);
            }
    */
    }
    #endregion
    
    public void OnEnable() => _controls.Player.Enable();
    private void OnDisable() => _controls.Player.Disable();
}

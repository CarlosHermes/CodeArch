using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(CapsuleCollider))]
public class FPSController_Old : MonoBehaviour, Controls.IPlayerActions
{
    [SerializeField] private Transform _cam;
    [SerializeField] public Controls _playerInput;
    private MoveBehaviour _moveBehaviour;
    private Bow _weapon;
    private Vector2 _moveAxis, _lookAxis;
    private Quaternion _targetBodyRotation, _targetCamRotation;
    private Animator _anim;

    [SerializeField] [Range(0.1f, 1f)] private float _mouseSensitivity;
    [SerializeField] [Range(0.1f, 1f)] private float _smoothCam;

    public void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _playerInput = new Controls();
        _playerInput.Player.SetCallbacks(this);
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _weapon = GetComponentInChildren<Bow>();
        if (_cam == null)
        {
            _cam = Camera.main.transform;
        }
    }

    public void FixedUpdate()
    {
        _moveBehaviour.MoveForward(_moveAxis);
        
        if (_cam.localRotation != _targetCamRotation)
            _cam.localRotation = Quaternion.Slerp(_cam.localRotation, _targetCamRotation, _smoothCam);
        if (transform.rotation != _targetBodyRotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetBodyRotation, _smoothCam);
    }

    #region INPUT_CALLBACKS
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _lookAxis += _mouseSensitivity * context.ReadValue<Vector2>();
            _lookAxis.y = Mathf.Clamp(_lookAxis.y, -85f, 90f);
            _targetBodyRotation = Quaternion.Euler(0f, _lookAxis.x, 0f);
            _targetCamRotation = Quaternion.Euler(-_lookAxis.y, 0f, 0f);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(_cam.position, _cam.forward, out var aimTo, Mathf.Infinity))
                _anim.SetTrigger("Shot");
                //_weapon.Shoot(aimTo.point);
            else
                _anim.SetTrigger("Shot");
                //_weapon.Shoot(_cam.forward * 50f);//_weapon.Shoot();//
        }
    }

    public void ShootArrow()
    {
        _weapon.Shoot();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            _moveAxis = context.ReadValue<Vector2>();
        else if (context.canceled)
            _moveAxis = Vector2.zero;
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed) ;
        //_weapon.Reload();
    }
    #endregion
    
    public void OnEnable() => _playerInput.Player.Enable();
    private void OnDisable() => _playerInput.Player.Disable();
}
*/
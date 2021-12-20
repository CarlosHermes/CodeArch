using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

public class DWeapon : MonoBehaviour
{
    [SerializeField] protected AnimancerComponent _animancer;
    [SerializeField] protected EquipItem _weapon;
    [SerializeField] protected GameObject _placeHolder;
    [SerializeField] protected ClipState.Transition _weaponAnim;
    
    protected bool _doubleTap;
    protected float _timer;
    
    protected AnimancerState _state;
    protected bool _readyToAttack;

    private void Awake()
    {
        _timer = Time.time;
        _doubleTap = false;
    }
    public virtual void PrepareAttack()
    {
        if (Time.deltaTime - _timer < 0.5f && (_state == null || !_state.IsPlaying))
        {
            _doubleTap = true;
            _state = _animancer.Play(_weaponAnim);
        }
        else _doubleTap = false;
    }

    public virtual void ReleaseAttack()
    {
        ;
    }
}

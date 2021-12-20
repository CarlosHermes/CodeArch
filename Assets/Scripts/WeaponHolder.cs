using System;
using Animancer;
using UnityEngine;

[Serializable]
public class WeaponHolder
{
    [SerializeField] protected WeaponItem _weaponItem;
    private AnimancerState _animState;

    public AnimancerState AnimState
    {
        get => _animState;
        set => _animState = value;
    }

    public WeaponHolder(WeaponItem weaponItem)
    {
        _weaponItem = weaponItem;
    }

    public WeaponItem WeaponItem => _weaponItem;

    public void StartAttack()
    {
        
    }

    public void StopAttack()
    {
        
    }
}
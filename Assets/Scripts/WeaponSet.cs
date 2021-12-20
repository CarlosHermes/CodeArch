using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSet : MonoBehaviour
{
    [SerializeField] private WeaponHolder _activeWeapon;
    [SerializeField] private List<WeaponHolder> _weapons;
    [SerializeField] private WeaponDataBase _ownedWeapons;
    
    public WeaponHolder ActiveWeapon
    {
        get => _activeWeapon;
        set => _activeWeapon = value;
    }

    private void Awake()
    {
        _weapons = new List<WeaponHolder>();
        foreach (var weaponItem in _ownedWeapons.Content)
        {
            _weapons.Add(new WeaponHolder(weaponItem));
        }
    }

    private void OnValidate()
    {
        Awake();
    }
}
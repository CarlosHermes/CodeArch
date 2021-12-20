using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class ScriptableItem : ScriptableObject
{
    [SerializeField] protected int _itemID;
    [SerializeField] private string _name;
    [SerializeField] protected Sprite _icon;
    [SerializeField][TextArea] protected string _description;
    [SerializeField] protected int _price;
    [SerializeField] protected bool _locked;
    [SerializeField] protected int _amount;
    [SerializeField] protected UnityEngine.Object _prefab;
    [SerializeField] protected bool _owned;
    public string Name
    {
        get => _name;
    }
    public int Id
    {
        get => _itemID;
    }
    
    public Sprite Icon
    {
        get => _icon;
        set => _icon = value;
    }
    
    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public int Price
    {
        get => _price;
        set => _price = value;
    }

    public bool Locked
    {
        get => _locked;
        set => _locked = value;
    }
    
    public int Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public UnityEngine.Object Prefab
    {
        get => _prefab;
        set => _prefab = value;
    }
    public bool Owned { get => _owned; set => _owned = value; }

    protected virtual void OnValidate()
    {
        _itemID = _name.GetHashCode();
    }
}

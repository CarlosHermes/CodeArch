using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class ScriptableList<T> : ScriptableObject
{
    [SerializeField] protected List<T> _content = new List<T>();

    public List<T> Content
    {
        get => _content;
        set => _content = value;
    }
}


